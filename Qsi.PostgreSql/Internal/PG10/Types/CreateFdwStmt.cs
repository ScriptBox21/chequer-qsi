/* Generated by QSI

 Date: 2020-08-07
 Span: 2199:1 - 2205:16
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("CreateFdwStmt")]
    internal sealed class CreateFdwStmt : IPg10Node
    {
        public NodeTag Type
        {
            get { return NodeTag.T_CreateFdwStmt; }
        }

        public string fdwname { get; set; }

        public IPg10Node[] func_options { get; set; }

        public IPg10Node[] options { get; set; }
    }
}
