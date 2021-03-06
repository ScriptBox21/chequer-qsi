/* Generated by QSI

 Date: 2020-08-12
 Span: 1030:1 - 1040:19
 File: src/postgres/include/nodes/execnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("MergeAppendState")]
    internal class MergeAppendState : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_MergeAppendState;

        public PlanState ps { get; set; }

        public PlanState[][] mergeplans { get; set; }

        public int? ms_nplans { get; set; }

        public int? ms_nkeys { get; set; }

        public SortSupportData[] ms_sortkeys { get; set; }

        public TupleTableSlot[][] ms_slots { get; set; }

        public binaryheap[] ms_heap { get; set; }

        public bool? ms_initialized { get; set; }
    }
}
