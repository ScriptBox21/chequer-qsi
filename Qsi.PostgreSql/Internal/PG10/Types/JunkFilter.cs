/* Generated by QSI

 Date: 2020-08-07
 Span: 329:1 - 337:13
 File: src/postgres/include/nodes/execnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("JunkFilter")]
    internal sealed class JunkFilter : IPg10Node
    {
        public NodeTag Type
        {
            get { return NodeTag.T_JunkFilter; }
        }

        public IPg10Node[] jf_targetList { get; set; }

        public tupleDesc jf_cleanTupType { get; set; }

        public short jf_cleanMap { get; set; }

        public TupleTableSlot jf_resultSlot { get; set; }

        public short jf_junkAttNo { get; set; }
    }
}
