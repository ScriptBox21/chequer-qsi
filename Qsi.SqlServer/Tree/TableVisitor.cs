﻿using System;
using Microsoft.SqlServer.Management.SqlParser.SqlCodeDom;
using Qsi.Data;
using Qsi.Tree.Base;
using Qsi.Utilities;

namespace Qsi.SqlServer.Tree
{
    internal static class TableVisitor
    {
        #region Tree
        public static QsiTableNode Visit(SqlCodeObject codeObject)
        {
            if (codeObject == null)
                return null;

            switch (codeObject)
            {
                case SqlSelectStatement selectStatement:
                    return VisitSelectStatement(selectStatement);
            }

            return null;
        }
        #endregion

        #region Select Statements
        public static QsiTableNode VisitSelectStatement(SqlSelectStatement selectStatement)
        {
            return VisitQueryExpression(selectStatement.SelectSpecification.QueryExpression);
        }

        public static QsiTableNode VisitQueryExpression(SqlQueryExpression queryExpression)
        {
            switch (queryExpression)
            {
                case SqlQuerySpecification querySpecification:
                    return VisitQuerySpecification(querySpecification);

                case SqlBinaryQueryExpression binaryQueryExpression:
                    return VisitBinaryQueryExpression(binaryQueryExpression);
            }

            return null;
        }

        private static QsiDerivedTableNode VisitQuerySpecification(SqlQuerySpecification querySpecification)
        {
            return TreeHelper.Create<QsiDerivedTableNode>(n =>
            {
                foreach (var codeObject in querySpecification.Children)
                {
                    switch (codeObject)
                    {
                        case SqlSelectClause selectClause:
                            n.Columns.SetValue(VisitSelectClause(selectClause));
                            break;

                        case SqlFromClause fromClause:
                            n.Source.SetValue(VisitFromClause(fromClause));
                            break;
                    }
                }
            });
        }

        private static QsiCompositeTableNode VisitBinaryQueryExpression(SqlBinaryQueryExpression binaryQueryExpression)
        {
            return TreeHelper.Create<QsiCompositeTableNode>(n =>
            {
                n.Sources.Add(VisitQueryExpression(binaryQueryExpression.Left));
                n.Sources.Add(VisitQueryExpression(binaryQueryExpression.Right));
            });
        }

        public static QsiColumnsDeclarationNode VisitSelectClause(SqlSelectClause selectClause)
        {
            return TreeHelper.Create<QsiColumnsDeclarationNode>(dn =>
            {
                foreach (var selectExpression in selectClause.SelectExpressions)
                {
                    switch (selectExpression)
                    {
                        case SqlSelectStarExpression starExpression:
                            dn.Columns.Add(VisitStarExpression(starExpression));
                            break;

                        case SqlSelectScalarExpression scalarExpression:
                            dn.Columns.Add(VisitSelectScalarExpression(scalarExpression));
                            break;
                    }
                }
            });
        }

        public static QsiTableNode VisitFromClause(SqlFromClause fromClause)
        {
            // TODO: TableExpressions에 대응 (현재는 바로 return)
            foreach (var tableExpression in fromClause.TableExpressions)
            {
                return VisitTableExpression(tableExpression);
            }

            return null;
        }

        private static QsiTableNode VisitTableExpression(SqlTableExpression tableExpression)
        {
            switch (tableExpression)
            {
                case SqlTableRefExpression tableRefExpression:
                    return VisitTableRefExpression(tableRefExpression);

                case SqlQualifiedJoinTableExpression qualifiedJoinTableExpression:
                    return VisitQualifiedJoinTableExpression(qualifiedJoinTableExpression);
            }

            return null;
        }

        private static QsiTableNode VisitTableRefExpression(SqlTableRefExpression tableRefExpression)
        {
            var tableNode = new QsiTableAccessNode
            {
                Identifier = IdentifierVisitor.VisitMultipartIdentifier(tableRefExpression.ObjectIdentifier)
            };

            if (tableRefExpression.Alias == null)
                return tableNode;

            return TreeHelper.Create<QsiDerivedTableNode>(n =>
            {
                var allDeclaration = new QsiColumnsDeclarationNode();
                allDeclaration.Columns.Add(new QsiAllColumnNode());

                n.Columns.SetValue(allDeclaration);
                n.Source.SetValue(tableNode);

                n.Alias.SetValue(new QsiAliasNode
                {
                    Name = new QsiIdentifier(tableRefExpression.Alias.Value, false)
                });
            });
        }

        private static QsiJoinedTableNode VisitQualifiedJoinTableExpression(SqlQualifiedJoinTableExpression qualifiedJoinTableExpression)
        {
            return TreeHelper.Create<QsiJoinedTableNode>(n =>
            {
                n.Left.SetValue(VisitTableExpression(qualifiedJoinTableExpression.Left));
                n.Right.SetValue(VisitTableExpression(qualifiedJoinTableExpression.Right));

                n.JoinType = qualifiedJoinTableExpression.JoinOperator switch
                {
                    SqlJoinOperatorType.CrossApply => QsiJoinType.Inner,
                    SqlJoinOperatorType.CrossJoin => QsiJoinType.Cross,
                    SqlJoinOperatorType.InnerJoin => QsiJoinType.Inner,
                    SqlJoinOperatorType.OuterApply => QsiJoinType.Left,
                    SqlJoinOperatorType.FullOuterJoin => QsiJoinType.Full,
                    SqlJoinOperatorType.LeftOuterJoin => QsiJoinType.Left,
                    SqlJoinOperatorType.RightOuterJoin => QsiJoinType.Right,
                    _ => throw new InvalidOperationException()
                };
            });
        }

        private static QsiColumnNode VisitSelectScalarExpression(SqlSelectScalarExpression scalarExpression)
        {
            var columnNode = new QsiDeclaredColumnNode
            {
                Name = IdentifierVisitor.VisitScalarExpression(scalarExpression.Expression),
            };

            if (scalarExpression.Alias == null)
                return columnNode;

            return TreeHelper.Create<QsiDerivedColumnNode>(n =>
            {
                n.Column.SetValue(columnNode);

                n.Alias.SetValue(new QsiAliasNode
                {
                    Name = new QsiIdentifier(scalarExpression.Alias.Value, false)
                });
            });
        }

        public static QsiColumnNode VisitStarExpression(SqlSelectStarExpression starExpression)
        {
            return new QsiAllColumnNode();
        }
        #endregion
    }
}
