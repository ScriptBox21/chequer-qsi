/* Generated by QSI

 Date: 2020-08-07
 Span: 1417:1 - 1421:14
 File: src/postgres/include/nodes/primnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("RangeTblRef")]
    internal sealed class RangeTblRef : IPg10Node
    {
        public NodeTag Type
        {
            get { return NodeTag.T_RangeTblRef; }
        }

        public int rtindex { get; set; }
    }
}
