/* Generated by QSI

 Date: 2020-08-12
 Span: 627:1 - 679:15
 File: src/postgres/include/nodes/relation.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("IndexOptInfo")]
    internal class IndexOptInfo : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_IndexOptInfo;

        public uint? indexoid { get; set; }

        public uint? reltablespace { get; set; }

        public RelOptInfo[] rel { get; set; }

        public uint? pages { get; set; }

        public double? tuples { get; set; }

        public int? tree_height { get; set; }

        public int? ncolumns { get; set; }

        public int[] indexkeys { get; set; }

        public uint[] indexcollations { get; set; }

        public uint[] opfamily { get; set; }

        public uint[] opcintype { get; set; }

        public uint[] sortopfamily { get; set; }

        public bool[] reverse_sort { get; set; }

        public bool[] nulls_first { get; set; }

        public bool[] canreturn { get; set; }

        public uint? relam { get; set; }

        public IPg10Node[] indexprs { get; set; }

        public IPg10Node[] indpred { get; set; }

        public IPg10Node[] indextlist { get; set; }

        public IPg10Node[] indrestrictinfo { get; set; }

        public bool? predOK { get; set; }

        public bool? unique { get; set; }

        public bool? immediate { get; set; }

        public bool? hypothetical { get; set; }

        public bool? amcanorderbyop { get; set; }

        public bool? amoptionalkey { get; set; }

        public bool? amsearcharray { get; set; }

        public bool? amsearchnulls { get; set; }

        public bool? amhasgettuple { get; set; }

        public bool? amhasgetbitmap { get; set; }

        public bool? amcanparallel { get; set; }

        public string[] amcostestimate { get; set; }
    }
}
