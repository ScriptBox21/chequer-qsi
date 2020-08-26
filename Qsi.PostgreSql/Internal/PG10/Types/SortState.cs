/* Generated by QSI

 Date: 2020-08-12
 Span: 1750:1 - 1760:12
 File: src/postgres/include/nodes/execnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("SortState")]
    internal class SortState : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_SortState;

        public ScanState ss { get; set; }

        public bool? randomAccess { get; set; }

        public bool? bounded { get; set; }

        public int? bound { get; set; }

        public bool? sort_Done { get; set; }

        public bool? bounded_Done { get; set; }

        public int? bound_Done { get; set; }

        public object[] tuplesortstate { get; set; }
    }
}