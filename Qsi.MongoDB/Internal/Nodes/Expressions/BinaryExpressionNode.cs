﻿using System.Collections.Generic;

namespace Qsi.MongoDB.Internal.Nodes
{
    public class BinaryExpressionNode : BaseNode, IExpressionNode
    {
        public string Operator { get; set; }
        
        public IExpressionNode Left { get; set; }
        
        public IExpressionNode Right { get; set; }

        public override IEnumerable<INode> Children
        {
            get
            {
                yield return Left;
                yield return Right;
            }
        }
    }
}