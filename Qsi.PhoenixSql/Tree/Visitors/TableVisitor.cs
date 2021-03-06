﻿using System;
using System.Collections.Generic;
using System.Linq;
using Google.Protobuf.Collections;
using PhoenixSql;
using PhoenixSql.Extensions;
using Qsi.Data;
using Qsi.Extensions;
using Qsi.Parsing;
using Qsi.PhoenixSql.Internal;
using Qsi.Shared.Extensions;
using Qsi.Tree;
using Qsi.Utilities;

namespace Qsi.PhoenixSql.Tree
{
    internal static class TableVisitor
    {
        public static QsiTableNode VisitSelectStatement(SelectStatement statement)
        {
            var tableNode = new PDerivedTableNode();
            var columnsNode = new QsiColumnsDeclarationNode();

            tableNode.Hints = statement.Hint?.Hints;

            RepeatedField<AliasedNode> selects = statement.Select;

            if (statement.IsUnion && selects.Select(s => s.Node.Unwrap()).TryCast(out IEnumerable<ColumnParseNode> columns))
            {
                columnsNode.Columns.AddRange(CreateSequentialColumns(columns));
            }
            else
            {
                columnsNode.Columns.AddRange(selects.Select(VisitAliasedNode));
            }

            tableNode.Columns.SetValue(columnsNode);

            if (statement.IsUnion)
            {
                tableNode.Source.SetValue(VisitSelectStatements(statement.Selects));
            }
            else if (statement.From != null)
            {
                tableNode.Source.SetValue(VisitTableNode(statement.From));
            }

            if (statement.Where != null)
                tableNode.Where.SetValue(ExpressionVisitor.VisitWhere(statement.Where));

            if (statement.Limit != null || statement.Offset != null)
                tableNode.Limit.SetValue(ExpressionVisitor.VisitLimitOffset(statement.Limit, statement.Offset));

            if (statement.OrderBy.Any())
                tableNode.Order.SetValue(ExpressionVisitor.VisitOrderBy(statement.OrderBy));

            // statement.GroupBy
            // statement.Having

            PTree.RawNode[tableNode] = statement;

            return tableNode;
        }

        public static IEnumerable<QsiSequentialColumnNode> CreateSequentialColumns(IEnumerable<ColumnParseNode> columns)
        {
            return columns.Select(c =>
            {
                var node = new QsiSequentialColumnNode();

                node.Alias.SetValue(new QsiAliasNode
                {
                    Name = IdentifierVisitor.Visit(c)[0]
                });

                PTree.RawNode[node] = c;

                return node;
            });
        }

        public static QsiTableNode VisitSelectStatements(IEnumerable<SelectStatement> statements)
        {
            return TreeHelper.Create<QsiCompositeTableNode>(n =>
            {
                n.Sources.AddRange(statements.Select(VisitSelectStatement));
            });
        }

        public static QsiColumnNode VisitAliasedNode(AliasedNode node)
        {
            var childNode = node.Node.UnwrapAs<IParseNode>();
            bool hasAlias = !string.IsNullOrEmpty(node.Alias);
            QsiColumnNode columnNode = null;
            QsiExpressionNode expressionNode = null;

            switch (childNode.Unwrap())
            {
                case INamedParseNode namedNode:
                    columnNode = VisitNamedParseNode(namedNode);
                    break;

                case WildcardParseNode wildcardParseNode:
                    columnNode = VisitWildcardParseNode(wildcardParseNode);
                    break;

                default:
                    expressionNode = ExpressionVisitor.Visit(childNode);
                    break;
            }

            if (columnNode != null && !hasAlias)
                return columnNode;

            return TreeHelper.Create<QsiDerivedColumnNode>(n =>
            {
                if (hasAlias)
                {
                    n.Alias.SetValue(new QsiAliasNode
                    {
                        Name = IdentifierVisitor.Visit(node)
                    });
                }

                if (columnNode != null)
                    n.Column.SetValue(columnNode);

                if (expressionNode != null)
                    n.Expression.SetValue(expressionNode);

                PTree.RawNode[n] = node;
            });
        }

        public static QsiColumnNode VisitNamedParseNode(INamedParseNode node)
        {
            switch (node.UnwrapAs<INamedParseNode>())
            {
                case FamilyWildcardParseNode familyWildcardParseNode:
                    return VisitFamilyWildcardParseNode(familyWildcardParseNode);

                case BindParseNode bindParseNode:
                    return VisitBindParseNode(bindParseNode);

                case ColumnParseNode columnParseNode:
                    return VisitColumnParseNode(columnParseNode);

                case TableWildcardParseNode tableWildcardParseNode:
                    return VisitTableWildcardParseNode(tableWildcardParseNode);

                default:
                    throw TreeHelper.NotSupportedTree(node);
            }
        }

        public static QsiColumnNode VisitWildcardParseNode(WildcardParseNode node)
        {
            var columnNode = new QsiAllColumnNode();
            PTree.RawNode[columnNode] = node;
            return columnNode;
        }

        public static QsiColumnNode VisitFamilyWildcardParseNode(FamilyWildcardParseNode node)
        {
            var columnNode = new QsiAllColumnNode();

            if (!string.IsNullOrEmpty(node.Name))
                columnNode.Path = new QsiQualifiedIdentifier(IdentifierVisitor.Visit(node));

            PTree.RawNode[columnNode] = node;

            return columnNode;
        }

        public static QsiColumnNode VisitBindParseNode(BindParseNode node)
        {
            var columnNode = new QsiBindingColumnNode
            {
                Id = $":{node.Index}"
            };

            PTree.RawNode[columnNode] = node;

            return columnNode;
        }

        public static QsiColumnNode VisitColumnParseNode(ColumnParseNode node)
        {
            var columnNode = new QsiDeclaredColumnNode
            {
                Name = IdentifierVisitor.Visit(node)
            };

            PTree.RawNode[columnNode] = node;

            return columnNode;
        }

        public static QsiColumnNode VisitTableWildcardParseNode(TableWildcardParseNode node)
        {
            var columnNode = new QsiAllColumnNode();

            if (!string.IsNullOrEmpty(node.Name))
                columnNode.Path = new QsiQualifiedIdentifier(IdentifierVisitor.Visit(node));

            PTree.RawNode[columnNode] = node;

            return columnNode;
        }

        public static QsiTableNode VisitTableNode(ITableNode node)
        {
            switch (node.Unwrap())
            {
                case NamedTableNode namedTableNode:
                    return VisitNamedTableNode(namedTableNode);

                case BindTableNode bindTableNode:
                    return VisitBindTableNode(bindTableNode);

                case JoinTableNode joinTableNode:
                    return VisitJoinTableNode(joinTableNode);

                case DerivedTableNode derivedTableNode:
                    return VisitDerivedTableNode(derivedTableNode);

                default:
                    throw TreeHelper.NotSupportedTree(node);
            }
        }

        public static QsiTableNode VisitNamedTableNode(NamedTableNode node)
        {
            var identifier = IdentifierVisitor.Visit(node.Name);

            QsiTableAccessNode tableNode;

            if (node.DynamicColumns.Any())
            {
                tableNode = TreeHelper.Create<PDynamicTableAccessNode>(n =>
                {
                    n.Identifier = identifier;
                    n.DynamicColumns = new QsiColumnsDeclarationNode();
                    n.DynamicColumns.Columns.AddRange(node.DynamicColumns.Select(VisitDynamicColumn));
                });
            }
            else
            {
                tableNode = new QsiTableAccessNode
                {
                    Identifier = identifier
                };
            }

            if (string.IsNullOrEmpty(node.Alias))
            {
                PTree.RawNode[tableNode] = node;
                return tableNode;
            }

            return TreeHelper.Create<QsiDerivedTableNode>(n =>
            {
                n.Columns.SetValue(TreeHelper.CreateAllColumnsDeclaration());
                n.Source.SetValue(tableNode);

                n.Alias.SetValue(new QsiAliasNode
                {
                    Name = IdentifierVisitor.Visit(node)
                });

                PTree.RawNode[n] = node;
            });
        }

        public static PDynamicDeclaredColumnNode VisitDynamicColumn(ColumnDef node)
        {
            return TreeHelper.Create<PDynamicDeclaredColumnNode>(n =>
            {
                n.Name = IdentifierVisitor.Visit(node.ColumnDefName);
                PTree.RawNode[n] = node;
            });
        }

        public static QsiTableNode VisitBindTableNode(BindTableNode node)
        {
            throw TreeHelper.NotSupportedFeature("Table binding");
        }

        public static QsiTableNode VisitJoinTableNode(JoinTableNode node)
        {
            var tableNode = new QsiJoinedTableNode
            {
                JoinType = node.Type switch
                {
                    JoinType.Inner => QsiJoinType.Inner,
                    JoinType.Left => QsiJoinType.Left,
                    JoinType.Right => QsiJoinType.Right,
                    JoinType.Full => QsiJoinType.Full,
                    JoinType.Semi => QsiJoinType.Semi,
                    JoinType.Anti => QsiJoinType.Anti,
                    _ => throw new ArgumentOutOfRangeException()
                }
            };

            tableNode.Left.SetValue(VisitTableNode(node.LHS));
            tableNode.Right.SetValue(VisitTableNode(node.RHS));

            // node.OnNode

            PTree.RawNode[tableNode] = node;

            return tableNode;
        }

        public static QsiTableNode VisitDerivedTableNode(DerivedTableNode node)
        {
            return TreeHelper.Create<QsiDerivedTableNode>(n =>
            {
                n.Columns.SetValue(TreeHelper.CreateAllColumnsDeclaration());
                n.Source.SetValue(VisitSelectStatement(node.Select));

                if (!string.IsNullOrEmpty(node.Alias))
                {
                    n.Alias.SetValue(new QsiAliasNode
                    {
                        Name = IdentifierVisitor.Visit(node)
                    });
                }

                PTree.RawNode[n] = node;
            });
        }

        public static IQsiTreeNode VisitCreateViewStatement(CreateTableStatement node)
        {
            QsiDerivedTableNode derivedTableNode;

            if (node.ColumnDefs.Any())
            {
                derivedTableNode = TreeHelper.Create<PDynamicDerivedTableNode>(n =>
                {
                    n.DynamicColumns = new QsiColumnsDeclarationNode();
                    n.DynamicColumns.Columns.AddRange(node.ColumnDefs.Select(VisitDynamicColumn));
                });
            }
            else
            {
                derivedTableNode = new PDerivedTableNode();
            }

            derivedTableNode.Alias.SetValue(new QsiAliasNode
            {
                Name = IdentifierVisitor.Visit(node.TableName)[^1]
            });

            derivedTableNode.Columns.SetValue(TreeHelper.CreateAllColumnsDeclaration());

            if (node.BaseTableName != null)
            {
                QsiTableNode tableNode = TreeHelper.Create<QsiTableAccessNode>(n =>
                {
                    n.Identifier = IdentifierVisitor.Visit(node.BaseTableName);
                    PTree.RawNode[n] = node.BaseTableName;
                });

                if (node.WhereClause != null)
                {
                    var sourceDerivedTableNode = new QsiDerivedTableNode();
                    sourceDerivedTableNode.Columns.SetValue(TreeHelper.CreateAllColumnsDeclaration());
                    sourceDerivedTableNode.Where.SetValue(ExpressionVisitor.VisitWhere(node.WhereClause));
                    sourceDerivedTableNode.Source.SetValue(tableNode);

                    derivedTableNode.Source.SetValue(sourceDerivedTableNode); 
                }
                else
                {
                    derivedTableNode.Source.SetValue(tableNode);   
                }
            }
            else
            {
                throw new QsiException(QsiError.Syntax);
            }

            PTree.RawNode[derivedTableNode] = node;

            return derivedTableNode;
        }
    }
}
