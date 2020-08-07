/* Generated by QSI

 Date: 2020-08-07
 Span: 1474:1 - 1483:13
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("UpdateStmt")]
    internal sealed class UpdateStmt : IPg10Node
    {
        public NodeTag Type
        {
            get { return NodeTag.T_UpdateStmt; }
        }

        public RangeVar relation { get; set; }

        public IPg10Node[] targetList { get; set; }

        public IPg10Node whereClause { get; set; }

        public IPg10Node[] fromClause { get; set; }

        public IPg10Node[] returningList { get; set; }

        public WithClause withClause { get; set; }
    }
}
