/* Generated by QSI

 Date: 2020-08-07
 Span: 2378:1 - 2385:22
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("CreateEventTrigStmt")]
    internal sealed class CreateEventTrigStmt : IPg10Node
    {
        public NodeTag Type
        {
            get { return NodeTag.T_CreateEventTrigStmt; }
        }

        public string trigname { get; set; }

        public string eventname { get; set; }

        public IPg10Node[] whenclause { get; set; }

        public IPg10Node[] funcname { get; set; }
    }
}
