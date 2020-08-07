/* Generated by QSI

 Date: 2020-08-07
 Span: 1701:1 - 1721:16
 File: src/postgres/include/nodes/execnodes.h

*/

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    internal sealed class HashJoinState
    {
        public JoinState js { get; set; }

        public ExprState hashclauses { get; set; }

        public IPg10Node[] hj_OuterHashKeys { get; set; }

        public IPg10Node[] hj_InnerHashKeys { get; set; }

        public IPg10Node[] hj_HashOperators { get; set; }

        public HashJoinTableData hj_HashTable { get; set; }

        public uint hj_CurHashValue { get; set; }

        public int hj_CurBucketNo { get; set; }

        public int hj_CurSkewBucketNo { get; set; }

        public HashJoinTupleData hj_CurTuple { get; set; }

        public TupleTableSlot hj_OuterTupleSlot { get; set; }

        public TupleTableSlot hj_HashTupleSlot { get; set; }

        public TupleTableSlot hj_NullOuterTupleSlot { get; set; }

        public TupleTableSlot hj_NullInnerTupleSlot { get; set; }

        public TupleTableSlot hj_FirstOuterTupleSlot { get; set; }

        public int hj_JoinState { get; set; }

        public bool hj_MatchedOuter { get; set; }

        public bool hj_OuterNotEmpty { get; set; }
    }
}
