/* Generated by QSI

 Date: 2020-08-07
 Span: 423:1 - 514:9
 File: src/postgres/include/nodes/execnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("EState")]
    internal sealed class EState : IPg10Node
    {
        public NodeTag Type
        {
            get { return NodeTag.T_EState; }
        }

        public ScanDirection es_direction { get; set; }

        public SnapshotData es_snapshot { get; set; }

        public SnapshotData es_crosscheck_snapshot { get; set; }

        public IPg10Node[] es_range_table { get; set; }

        public PlannedStmt es_plannedstmt { get; set; }

        public char es_sourceText { get; set; }

        public JunkFilter es_junkFilter { get; set; }

        public uint es_output_cid { get; set; }

        public ResultRelInfo es_result_relations { get; set; }

        public int es_num_result_relations { get; set; }

        public ResultRelInfo es_result_relation_info { get; set; }

        public ResultRelInfo es_root_result_relations { get; set; }

        public int es_num_root_result_relations { get; set; }

        public IPg10Node[] es_leaf_result_relations { get; set; }

        public IPg10Node[] es_trig_target_relations { get; set; }

        public TupleTableSlot es_trig_tuple_slot { get; set; }

        public TupleTableSlot es_trig_oldtup_slot { get; set; }

        public TupleTableSlot es_trig_newtup_slot { get; set; }

        public ParamListInfoData es_param_list_info { get; set; }

        public ParamExecData es_param_exec_vals { get; set; }

        public QueryEnvironment es_queryEnv { get; set; }

        public MemoryContextData[] es_query_cxt { get; set; }

        public IPg10Node[] es_tupleTable { get; set; }

        public IPg10Node[] es_rowMarks { get; set; }

        public uint es_processed { get; set; }

        public uint es_lastoid { get; set; }

        public int es_top_eflags { get; set; }

        public int es_instrument { get; set; }

        public bool es_finished { get; set; }

        public IPg10Node[] es_exprcontexts { get; set; }

        public IPg10Node[] es_subplanstates { get; set; }

        public IPg10Node[] es_auxmodifytables { get; set; }

        public ExprContext es_per_tuple_exprcontext { get; set; }

        public HeapTupleData es_epqTuple { get; set; }

        public bool[] es_epqTupleSet { get; set; }

        public bool[] es_epqScanDone { get; set; }

        public dsa_area es_query_dsa { get; set; }

        public bool es_use_parallel_mode { get; set; }
    }
}
