/* Generated by QSI

 Date: 2020-08-07
 Span: 798:1 - 812:21
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("PartitionBoundSpec")]
    internal sealed class PartitionBoundSpec : IPg10Node
    {
        public NodeTag Type
        {
            get { return NodeTag.T_PartitionBoundSpec; }
        }

        public char strategy { get; set; }

        public IPg10Node[] listdatums { get; set; }

        public IPg10Node[] lowerdatums { get; set; }

        public IPg10Node[] upperdatums { get; set; }

        public int location { get; set; }
    }
}
