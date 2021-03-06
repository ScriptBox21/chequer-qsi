/* Generated by QSI

 Date: 2020-08-12
 Span: 707:1 - 717:12
 File: src/postgres/include/nodes/plannodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("MergeJoin")]
    internal class MergeJoin : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_MergeJoin;

        public Join join { get; set; }

        public bool? skip_mark_restore { get; set; }

        public IPg10Node[] mergeclauses { get; set; }

        public uint[] mergeFamilies { get; set; }

        public uint[] mergeCollations { get; set; }

        public int[] mergeStrategies { get; set; }

        public bool[] mergeNullsFirst { get; set; }
    }
}
