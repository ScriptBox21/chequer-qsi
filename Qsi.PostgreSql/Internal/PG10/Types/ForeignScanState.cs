/* Generated by QSI

 Date: 2020-08-07
 Span: 1552:1 - 1560:19
 File: src/postgres/include/nodes/execnodes.h

*/

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    internal sealed class ForeignScanState
    {
        public ScanState ss { get; set; }

        public ExprState fdw_recheck_quals { get; set; }

        public uint pscan_len { get; set; }

        public FdwRoutine fdwroutine { get; set; }

        public object[] fdw_state { get; set; }
    }
}
