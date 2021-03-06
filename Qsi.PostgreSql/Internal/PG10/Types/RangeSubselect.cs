/* Generated by QSI

 Date: 2020-08-12
 Span: 531:1 - 537:17
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("RangeSubselect")]
    internal class RangeSubselect : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_RangeSubselect;

        public bool? lateral { get; set; }

        public IPg10Node[] subquery { get; set; }

        public Alias[] alias { get; set; }
    }
}
