/* Generated by QSI

 Date: 2020-08-07
 Span: 3101:1 - 3107:13
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("VacuumStmt")]
    internal sealed class VacuumStmt : IPg10Node
    {
        public NodeTag Type
        {
            get { return NodeTag.T_VacuumStmt; }
        }

        public int options { get; set; }

        public RangeVar relation { get; set; }

        public IPg10Node[] va_cols { get; set; }
    }
}
