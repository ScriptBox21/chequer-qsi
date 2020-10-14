﻿using System.Collections.Generic;
using Qsi.Tree.Data;
using Qsi.Utilities;

namespace Qsi.Tree.Immutable
{
    public readonly struct ImmutableWhereExpressionNode : IQsiWhereExpressionNode
    {
        public IQsiTreeNode Parent { get; }

        public IUserDataHolder UserData { get; }

        public IQsiExpressionNode Expression { get; }

        public IEnumerable<IQsiTreeNode> Children => TreeHelper.YieldChildren(Expression);

        public ImmutableWhereExpressionNode(
            IQsiTreeNode parent,
            IUserDataHolder userData,
            IQsiExpressionNode expression)
        {
            Parent = parent;
            UserData = userData;
            Expression = expression;
        }
    }
}
