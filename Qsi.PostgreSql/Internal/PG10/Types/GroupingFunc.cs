/* Generated by QSI

 Date: 2020-08-07
 Span: 338:1 - 347:15
 File: src/postgres/include/nodes/primnodes.h

*/

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    internal sealed class GroupingFunc
    {
        public Expr xpr { get; set; }

        public IPg10Node[] args { get; set; }

        public IPg10Node[] refs { get; set; }

        public IPg10Node[] cols { get; set; }

        public uint agglevelsup { get; set; }

        public int location { get; set; }
    }
}
