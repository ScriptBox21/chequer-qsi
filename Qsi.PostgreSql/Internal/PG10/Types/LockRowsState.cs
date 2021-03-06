/* Generated by QSI

 Date: 2020-08-12
 Span: 2017:1 - 2024:16
 File: src/postgres/include/nodes/execnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("LockRowsState")]
    internal class LockRowsState : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_LockRowsState;

        public PlanState ps { get; set; }

        public IPg10Node[] lr_arowMarks { get; set; }

        public EPQState lr_epqstate { get; set; }

        public HeapTupleData[][] lr_curtuples { get; set; }

        public int? lr_ntables { get; set; }
    }
}
