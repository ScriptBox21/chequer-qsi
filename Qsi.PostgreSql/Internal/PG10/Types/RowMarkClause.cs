/* Generated by QSI

 Date: 2020-08-07
 Span: 1306:1 - 1313:16
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("RowMarkClause")]
    internal sealed class RowMarkClause : IPg10Node
    {
        public NodeTag Type
        {
            get { return NodeTag.T_RowMarkClause; }
        }

        public uint rti { get; set; }

        public LockClauseStrength strength { get; set; }

        public LockWaitPolicy waitPolicy { get; set; }

        public bool pushedDown { get; set; }
    }
}
