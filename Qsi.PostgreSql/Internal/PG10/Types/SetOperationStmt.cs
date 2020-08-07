/* Generated by QSI

 Date: 2020-08-07
 Span: 1573:1 - 1588:19
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("SetOperationStmt")]
    internal sealed class SetOperationStmt : IPg10Node
    {
        public NodeTag Type
        {
            get { return NodeTag.T_SetOperationStmt; }
        }

        public SetOperation op { get; set; }

        public bool all { get; set; }

        public IPg10Node larg { get; set; }

        public IPg10Node rarg { get; set; }

        public IPg10Node[] colTypes { get; set; }

        public IPg10Node[] colTypmods { get; set; }

        public IPg10Node[] colCollations { get; set; }

        public IPg10Node[] groupClauses { get; set; }
    }
}
