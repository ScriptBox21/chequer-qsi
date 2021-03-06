/* Generated by QSI

 Date: 2020-08-12
 Span: 118:1 - 164:7
 File: src/postgres/include/nodes/plannodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("Plan")]
    internal class Plan : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_Plan;

        public double? startup_cost { get; set; }

        public double? total_cost { get; set; }

        public double? plan_rows { get; set; }

        public int? plan_width { get; set; }

        public bool? parallel_aware { get; set; }

        public bool? parallel_safe { get; set; }

        public int? plan_node_id { get; set; }

        public IPg10Node[] targetlist { get; set; }

        public IPg10Node[] qual { get; set; }

        public Plan[] lefttree { get; set; }

        public Plan[] righttree { get; set; }

        public IPg10Node[] initPlan { get; set; }

        public Bitmapset[] extParam { get; set; }

        public Bitmapset[] allParam { get; set; }
    }
}
