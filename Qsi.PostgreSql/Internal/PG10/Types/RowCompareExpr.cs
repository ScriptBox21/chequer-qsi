/* Generated by QSI

 Date: 2020-08-07
 Span: 1028:1 - 1037:17
 File: src/postgres/include/nodes/primnodes.h

*/

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    internal sealed class RowCompareExpr
    {
        public Expr xpr { get; set; }

        public RowCompareType rctype { get; set; }

        public IPg10Node[] opnos { get; set; }

        public IPg10Node[] opfamilies { get; set; }

        public IPg10Node[] inputcollids { get; set; }

        public IPg10Node[] largs { get; set; }

        public IPg10Node[] rargs { get; set; }
    }
}
