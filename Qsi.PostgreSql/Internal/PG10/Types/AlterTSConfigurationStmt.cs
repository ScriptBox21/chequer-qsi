/* Generated by QSI

 Date: 2020-08-12
 Span: 3358:1 - 3373:27
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("AlterTSConfigurationStmt")]
    internal class AlterTSConfigurationStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_AlterTSConfigurationStmt;

        public AlterTSConfigType? kind { get; set; }

        public IPg10Node[] cfgname { get; set; }

        public IPg10Node[] tokentype { get; set; }

        public IPg10Node[] dicts { get; set; }

        public bool? @override { get; set; }

        public bool? replace { get; set; }

        public bool? missing_ok { get; set; }
    }
}
