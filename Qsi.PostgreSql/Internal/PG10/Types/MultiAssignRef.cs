/* Generated by QSI

 Date: 2020-08-07
 Span: 454:1 - 460:17
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("MultiAssignRef")]
    internal sealed class MultiAssignRef : IPg10Node
    {
        public NodeTag Type
        {
            get { return NodeTag.T_MultiAssignRef; }
        }

        public IPg10Node source { get; set; }

        public int colno { get; set; }

        public int ncolumns { get; set; }
    }
}
