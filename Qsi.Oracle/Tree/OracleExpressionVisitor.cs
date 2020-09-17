﻿using net.sf.jsqlparser.schema;
using Qsi.JSql.Tree;
using Qsi.Tree.Base;

namespace Qsi.Oracle.Tree
{
    internal sealed class OracleExpressionVisitor : JSqlExpressionVisitor
    {
        public OracleExpressionVisitor(IJSqlVisitorContext context) : base(context)
        {
        }

        public override QsiExpressionNode VisitColumn(Column expression)
        {
            var expressionNode = base.VisitColumn(expression);

            if (expressionNode is QsiColumnExpressionNode columnExpression &&
                columnExpression.Column.Value is QsiDerivedColumnNode derivedColumn &&
                derivedColumn.Expression != null)
            {
                return derivedColumn.Expression.Value;
            }

            return expressionNode;
        }
    }
}