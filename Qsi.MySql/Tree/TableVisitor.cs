﻿using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Tree;
using Qsi.Data;
using Qsi.MySql.Internal;
using Qsi.MySql.Tree.Common;
using Qsi.Tree.Base;
using Qsi.Utilities;
using static Qsi.MySql.Internal.MySqlParser;

namespace Qsi.MySql.Tree
{
    internal static class TableVisitor
    {
        #region Tree
        public static IEnumerable<QsiTableNode> Visit(IParseTree tree)
        {
            switch (tree)
            {
                case RootContext rootContext:
                    return VisitRoot(rootContext);

                case SqlStatementContext statementContext:
                    return new[] { VisitSqlStatement(statementContext) };

                case SelectStatementContext selectStatementContext:
                    return new[] { VisitSelectStatement(selectStatementContext) };
            }

            return Enumerable.Empty<QsiTableNode>();
        }

        private static IEnumerable<QsiTableNode> VisitRoot(RootContext context)
        {
            if (context.sqlStatements() == null)
                yield break;

            foreach (var statementContext in context.sqlStatements().sqlStatement())
            {
                var r = VisitSqlStatement(statementContext);

                if (r != null)
                    yield return r;
            }
        }

        private static QsiTableNode VisitSqlStatement(SqlStatementContext context)
        {
            if (context.children.Count == 0)
                return null;

            switch (context.children[0])
            {
                case DmlStatementContext dmlStatementContext:
                    return VisitDmlStatement(dmlStatementContext);

                case DdlStatementContext ddlStatementContext:
                    return VisitDdlStatement(ddlStatementContext);
            }

            return null;
        }

        private static QsiTableNode VisitDmlStatement(DmlStatementContext context)
        {
            if (context.selectStatement() != null)
            {
                return VisitSelectStatement(context.selectStatement());
            }

            return null;
        }

        private static QsiTableNode VisitDdlStatement(DdlStatementContext context)
        {
            if (context.createView() != null)
            {
                return VisitCreateView(context.createView());
            }

            return null;
        }
        #endregion

        #region Columns
        private static IEnumerable<QsiSequentialColumnNode> CreateSequentialColumnNodes(IEnumerable<UidContext> uids)
        {
            return uids
                .Select((uid, i) => TreeHelper.Create<QsiSequentialColumnNode>(n =>
                {
                    n.Ordinal = i;
                    n.Alias.SetValue(CreateAliasNode(uid));
                }));
        }
        #endregion

        #region Alias
        private static QsiAliasNode CreateAliasNode(UidContext context)
        {
            return new QsiAliasNode
            {
                Name = IdentifierVisitor.VisitUid(context)
            };
        }
        #endregion

        #region Create View Statement
        private static QsiTableNode VisitCreateView(CreateViewContext context)
        {
            return TreeHelper.Create<QsiDerivedTableNode>(n =>
            {
                var viewAccessNode = VisitFullId(context.fullId());
                var columnsDeclaration = new QsiColumnsDeclarationNode();

                if (context.uidList() != null)
                {
                    columnsDeclaration.Columns.AddRange(CreateSequentialColumnNodes(context.uidList().uid()));
                }
                else
                {
                    columnsDeclaration.Columns.Add(new QsiAllColumnNode());
                }

                n.Columns.SetValue(columnsDeclaration);
                n.Source.SetValue(VisitSelectStatement(context.selectStatement()));

                n.Alias.SetValue(new QsiAliasNode
                {
                    Name = viewAccessNode.Identifier.Identifiers[^1]
                });
            });
        }
        #endregion

        #region Select Statements
        internal static QsiTableNode VisitSelectStatement(SelectStatementContext context)
        {
            WithClauseContext withClauseContext = null;
            QsiTableNode tableNode = null;

            switch (context)
            {
                case SimpleSelectContext simpleSelectContext:
                    withClauseContext = simpleSelectContext.withClause();
                    tableNode = VisitSimpleSelect(simpleSelectContext);
                    break;

                case ParenthesisSelectContext parenthesisSelect:
                    withClauseContext = parenthesisSelect.withClause();
                    tableNode = VisitParenthesisSelect(parenthesisSelect);
                    break;

                case UnionSelectContext unionSelect:
                    withClauseContext = unionSelect.withClause();
                    tableNode = VisitUnionSelect(unionSelect);
                    break;

                case UnionParenthesisSelectContext unionParenthesisSelect:
                    withClauseContext = unionParenthesisSelect.withClause();
                    tableNode = VisitUnionParenthesisSelect(unionParenthesisSelect);
                    break;
            }

            if (withClauseContext == null)
            {
                return tableNode;
            }

            if (!(tableNode is QsiDerivedTableNode derivedTableNode))
            {
                derivedTableNode = TreeHelper.Create<QsiDerivedTableNode>(dn =>
                {
                    dn.Source.SetValue(tableNode);

                    dn.Columns.SetValue(TreeHelper.Create<QsiColumnsDeclarationNode>(cdn =>
                    {
                        cdn.Columns.Add(new QsiAllColumnNode());
                    }));

                    // TODO: alias test
                });
            }

            derivedTableNode.Directives.SetValue(VisitWithClause(withClauseContext));

            return derivedTableNode;
        }

        private static QsiTableDirectivesNode VisitWithClause(WithClauseContext context)
        {
            return TreeHelper.Create<QsiTableDirectivesNode>(n =>
            {
                n.Tables.AddRange(context.withExpression().Select(VisitWithExpression));
            });
        }

        private static QsiTableNode VisitWithExpression(WithExpressionContext context)
        {
            return TreeHelper.Create<QsiDerivedTableNode>(n =>
            {
                var columnsDeclaration = new QsiColumnsDeclarationNode();

                if (context.columns != null)
                {
                    columnsDeclaration.Columns.AddRange(CreateSequentialColumnNodes(context.columns.uid()));
                }
                else
                {
                    columnsDeclaration.Columns.Add(new QsiAllColumnNode());
                }

                n.Columns.SetValue(columnsDeclaration);
                n.Source.SetValue(VisitSelectStatement(context.selectStatement()));
                n.Alias.SetValue(CreateAliasNode(context.alias));
            });
        }

        private static QsiTableNode VisitSimpleSelect(SimpleSelectContext context)
        {
            return VisitQuerySpecification(context.querySpecification());
        }

        private static QsiTableNode VisitParenthesisSelect(ParenthesisSelectContext context)
        {
            return VisitQueryExpression(context.queryExpression());
        }

        private static QsiTableNode VisitUnionSelect(UnionSelectContext context)
        {
            return TreeHelper.Create<QsiCompositeTableNode>(n =>
            {
                n.Sources.Add(VisitQuerySpecificationNointo(context.querySpecificationNointo()));
                n.Sources.AddRange(context.unionStatement().Select(VisitUnionStatement));

                if (context.querySpecification() != null)
                    n.Sources.Add(VisitQuerySpecification(context.querySpecification()));

                if (context.queryExpression() != null)
                    n.Sources.Add(VisitQueryExpression(context.queryExpression()));
            });
        }

        private static QsiTableNode VisitUnionParenthesisSelect(UnionParenthesisSelectContext context)
        {
            return TreeHelper.Create<QsiCompositeTableNode>(n =>
            {
                n.Sources.Add(VisitQueryExpressionNointo(context.queryExpressionNointo()));
                n.Sources.AddRange(context.unionParenthesis().Select(VisitUnionParenthesis));

                if (context.queryExpression() != null)
                    n.Sources.Add(VisitQueryExpression(context.queryExpression()));
            });
        }

        private static QsiTableNode VisitUnionStatement(UnionStatementContext context)
        {
            if (context.querySpecificationNointo() != null)
                return VisitQuerySpecificationNointo(context.querySpecificationNointo());

            if (context.queryExpressionNointo() != null)
                return VisitQueryExpressionNointo(context.queryExpressionNointo());

            return null;
        }

        private static QsiTableNode VisitUnionParenthesis(UnionParenthesisContext context)
        {
            return VisitQueryExpressionNointo(context.queryExpressionNointo());
        }
        #endregion

        #region Select Query Specification
        private static QsiTableNode VisitQueryExpression(QueryExpressionContext context)
        {
            while (true)
            {
                if (context.querySpecification() != null)
                    return VisitQuerySpecification(context.querySpecification());

                if (context.queryExpression() != null)
                {
                    context = context.queryExpression();
                    continue;
                }

                return null;
            }
        }

        private static QsiTableNode VisitQuerySpecification(QuerySpecificationContext context)
        {
            return VisitCommonSelectContext(new CommonSelectContext(context));
        }

        private static QsiTableNode VisitQueryExpressionNointo(QueryExpressionNointoContext context)
        {
            while (true)
            {
                if (context.querySpecificationNointo() != null)
                    return VisitQuerySpecificationNointo(context.querySpecificationNointo());

                if (context.queryExpressionNointo() != null)
                {
                    context = context.queryExpressionNointo();
                    continue;
                }

                throw TreeHelper.NotSupportedTree(context);
            }
        }

        private static QsiTableNode VisitQuerySpecificationNointo(QuerySpecificationNointoContext context)
        {
            return VisitCommonSelectContext(new CommonSelectContext(context));
        }
        #endregion

        #region Select Elements
        private static QsiTableNode VisitCommonSelectContext(CommonSelectContext context)
        {
            return TreeHelper.Create<QsiDerivedTableNode>(n =>
            {
                n.Columns.SetValue(VisitSelectElements(context.SelectElements));

                if (context.FromClause != null)
                {
                    n.Source.SetValue(VisitTableSources(context.FromClause.tableSources()));
                }
            });
        }

        private static QsiColumnsDeclarationNode VisitSelectElements(SelectElementsContext context)
        {
            return TreeHelper.Create<QsiColumnsDeclarationNode>(n =>
            {
                if (context.star != null)
                    n.Columns.Add(new QsiAllColumnNode());

                n.Columns.AddRange(context.selectElement().Select(VisitSelectElement));
            });
        }

        private static QsiColumnNode VisitSelectElement(SelectElementContext context)
        {
            switch (context)
            {
                case SelectStarElementContext starElementContext:
                {
                    return new QsiAllColumnNode
                    {
                        Path = IdentifierVisitor.VisitFullId(starElementContext.fullId())
                    };
                }

                case SelectColumnElementContext columnElementContext:
                {
                    var derivedColumn = new QsiDeclaredColumnNode
                    {
                        Name = IdentifierVisitor.Visit(columnElementContext.fullColumnName())
                    };

                    if (columnElementContext.alias == null)
                        return derivedColumn;

                    return TreeHelper.Create<QsiDerivedColumnNode>(n =>
                    {
                        n.Column.SetValue(derivedColumn);
                        n.Alias.SetValue(CreateAliasNode(columnElementContext.alias));
                    });
                }

                case SelectFunctionElementContext functionElementContext:
                {
                    return TreeHelper.Create<QsiDerivedColumnNode>(n =>
                    {
                        n.Expression.SetValue(ExpressionVisitor.VisitFunctionCall(functionElementContext.functionCall()));

                        if (functionElementContext.alias != null)
                            n.Alias.SetValue(CreateAliasNode(functionElementContext.alias));
                    });
                }

                case SelectExpressionElementContext expressionElementContext:
                {
                    var expression = ExpressionVisitor.VisitExpression(expressionElementContext.expression());

                    if (expressionElementContext.localIdAssign() != null)
                    {
                        expression = ExpressionVisitor.VisitLocalIdAssign(
                            expressionElementContext.localIdAssign(),
                            expression);
                    }

                    return TreeHelper.Create<QsiDerivedColumnNode>(n =>
                    {
                        n.Expression.SetValue(expression);

                        if (expressionElementContext.alias != null)
                            n.Alias.SetValue(CreateAliasNode(expressionElementContext.alias));
                    });
                }
            }

            return null;
        }
        #endregion

        #region From Clause
        private static QsiTableNode VisitTableSources(TableSourcesContext context)
        {
            QsiTableNode[] sources = context.tableSource()
                .Select(VisitTableSource)
                .ToArray();

            if (sources.Length == 1)
            {
                return sources[0];
            }

            if (sources.Length > 1)
            {
                // comma join

                var anchor = sources[0];

                foreach (var source in sources.Skip(1))
                {
                    var nextJoin = new QsiJoinedTableNode
                    {
                        JoinType = QsiJoinType.Full
                    };

                    nextJoin.Left.SetValue(anchor);
                    nextJoin.Right.SetValue(source);
                    anchor = nextJoin;
                }

                return anchor;
            }

            return null;
        }

        private static QsiTableNode VisitTableSource(TableSourceContext context)
        {
            switch (context)
            {
                case TableSourceBaseContext baseContext:
                {
                    return VisitTableSource(new CommonTableSourceContext(baseContext));
                }

                case TableSourceNestedContext nestedContext:
                {
                    return TreeHelper.Create<QsiDerivedTableNode>(n =>
                    {
                        var allDeclaration = new QsiColumnsDeclarationNode();
                        allDeclaration.Columns.Add(new QsiAllColumnNode());

                        n.Columns.SetValue(allDeclaration);
                        n.Source.SetValue(VisitTableSource(new CommonTableSourceContext(nestedContext)));
                    });
                }

                default:
                {
                    throw new NotSupportedException();
                }
            }
        }

        private static QsiTableNode VisitTableSourceItem(TableSourceItemContext context)
        {
            switch (context)
            {
                case AtomTableItemContext atomTableItemContext:
                    return VisitAtomTableItem(atomTableItemContext);

                case SubqueryTableItemContext subqueryTableItemContext:
                    return VisitSubqueryTableItem(subqueryTableItemContext);

                case TableSourcesItemContext tableSourcesItemContext:
                    return VisitTableSourcesItem(tableSourcesItemContext);

                default:
                    throw new NotSupportedException();
            }
        }

        private static QsiTableNode VisitTableSource(CommonTableSourceContext context)
        {
            var anchor = VisitTableSourceItem(context.TableSourceItem);

            if (context.JoinPart?.Length > 0)
            {
                foreach (var join in context.JoinPart)
                {
                    QsiJoinType joinType;
                    TableSourceItemContext sourceItemContext;
                    UidListContext uidListContext = null;

                    switch (join)
                    {
                        case InnerJoinContext innerJoinContext:
                            joinType = QsiJoinType.Inner;
                            sourceItemContext = innerJoinContext.tableSourceItem();
                            uidListContext = innerJoinContext.uidList();
                            break;

                        case StraightJoinContext straightJoinContext:
                            joinType = QsiJoinType.Full;
                            sourceItemContext = straightJoinContext.tableSourceItem();
                            break;

                        case OuterJoinContext outerJoinContext:
                            joinType = outerJoinContext.joinOuter().joinType.Type == MySqlLexer.LEFT ?
                                QsiJoinType.LeftOuter : QsiJoinType.RightOuter;

                            sourceItemContext = outerJoinContext.tableSourceItem();
                            uidListContext = outerJoinContext.uidList();
                            break;

                        case NaturalJoinContext naturalJoinContext:
                            joinType = naturalJoinContext.joinOuter().joinType.Type == MySqlLexer.LEFT ?
                                QsiJoinType.LeftOuter : QsiJoinType.RightOuter;

                            sourceItemContext = naturalJoinContext.tableSourceItem();
                            break;

                        default:
                            throw new NotSupportedException();
                    }

                    var nextJoin = new QsiJoinedTableNode
                    {
                        JoinType = joinType
                    };

                    nextJoin.Left.SetValue(anchor);
                    nextJoin.Right.SetValue(VisitTableSourceItem(sourceItemContext));

                    // PivotColumns: USING (..)
                    if (uidListContext != null)
                    {
                        IEnumerable<QsiDeclaredColumnNode> columns = uidListContext.uid()
                            .Select(uid => new QsiDeclaredColumnNode
                            {
                                Name = new QsiQualifiedIdentifier(IdentifierVisitor.VisitUid(uid))
                            });

                        var columnsDeclaration = TreeHelper.Create<QsiColumnsDeclarationNode>(dn =>
                        {
                            dn.Columns.AddRange(columns);
                        });

                        nextJoin.PivotColumns.SetValue(columnsDeclaration);
                    }

                    anchor = nextJoin;
                }
            }

            return anchor;
        }

        // .. FROM db.table [AS alias]
        private static QsiTableNode VisitAtomTableItem(AtomTableItemContext context)
        {
            var tableNode = new QsiTableAccessNode
            {
                Identifier = IdentifierVisitor.VisitFullId(context.tableName().fullId())
            };

            if (context.alias == null)
                return tableNode;

            return TreeHelper.Create<QsiDerivedTableNode>(n =>
            {
                n.Source.SetValue(tableNode);
                n.Alias.SetValue(CreateAliasNode(context.alias));
            });
        }

        private static QsiTableAccessNode VisitFullId(FullIdContext context)
        {
            return new QsiTableAccessNode
            {
                Identifier = IdentifierVisitor.VisitFullId(context)
            };
        }

        // .. FROM (subquery) alias
        private static QsiTableNode VisitSubqueryTableItem(SubqueryTableItemContext context)
        {
            if (context.alias == null)
                throw new Exception("Every derived table must have its own alias");

            return TreeHelper.Create<QsiDerivedTableNode>(n =>
            {
                var allDeclaration = new QsiColumnsDeclarationNode();
                allDeclaration.Columns.Add(new QsiAllColumnNode());

                n.Columns.SetValue(allDeclaration);
                n.Source.SetValue(VisitSelectStatement(context.selectStatement()));
                n.Alias.SetValue(CreateAliasNode(context.alias));
            });
        }

        // .. FROM (sources, ..)
        private static QsiTableNode VisitTableSourcesItem(TableSourcesItemContext context)
        {
            return VisitTableSources(context.tableSources());
        }
        #endregion
    }
}