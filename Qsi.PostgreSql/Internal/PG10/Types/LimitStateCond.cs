/* Generated by QSI

 Date: 2020-08-12
 Span: 2038:1 - 2047:17
 File: src/postgres/include/nodes/execnodes.h

*/

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    internal enum LimitStateCond
    {
        LIMIT_INITIAL = 0,
        LIMIT_RESCAN = 1,
        LIMIT_EMPTY = 2,
        LIMIT_INWINDOW = 3,
        LIMIT_SUBPLANEOF = 4,
        LIMIT_WINDOWEND = 5,
        LIMIT_WINDOWSTART = 6
    }
}
