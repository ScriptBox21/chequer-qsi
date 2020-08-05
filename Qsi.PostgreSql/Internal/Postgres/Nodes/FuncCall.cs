// Generate from postgres/src/include/nodes/parsenodes.h

namespace Qsi.PostgreSql.Internal.Postgres.Nodes
{
    [PgNode("FuncCall")]
    internal class FuncCall : IPgTree
    {
        public IPgTree[] funcname { get; set; }

        public IPgTree[] args { get; set; }

        public IPgTree[] agg_order { get; set; }

        public IPgTree agg_filter { get; set; }

        public bool agg_within_group { get; set; }

        public bool agg_star { get; set; }

        public bool agg_distinct { get; set; }

        public bool func_variadic { get; set; }

        public WindowDef over { get; set; }

        public int location { get; set; }
    }
}
