/* Generated by QSI

 Date: 2020-08-12
 Span: 557:1 - 561:16
 File: src/postgres/include/nodes/plannodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("WorkTableScan")]
    internal class WorkTableScan : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_WorkTableScan;

        public Scan scan { get; set; }

        public int? wtParam { get; set; }
    }
}
