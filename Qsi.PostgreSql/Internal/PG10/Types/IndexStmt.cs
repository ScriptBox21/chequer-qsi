/* Generated by QSI

 Date: 2020-08-12
 Span: 2696:1 - 2718:12
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("IndexStmt")]
    internal class IndexStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_IndexStmt;

        public string idxname { get; set; }

        public RangeVar[] relation { get; set; }

        public string accessMethod { get; set; }

        public string tableSpace { get; set; }

        public IPg10Node[] indexParams { get; set; }

        public IPg10Node[] options { get; set; }

        public IPg10Node[] whereClause { get; set; }

        public IPg10Node[] excludeOpNames { get; set; }

        public string idxcomment { get; set; }

        public uint? indexOid { get; set; }

        public uint? oldNode { get; set; }

        public bool? unique { get; set; }

        public bool? primary { get; set; }

        public bool? isconstraint { get; set; }

        public bool? deferrable { get; set; }

        public bool? initdeferred { get; set; }

        public bool? transformed { get; set; }

        public bool? concurrent { get; set; }

        public bool? if_not_exists { get; set; }
    }
}