/* Generated by QSI

 Date: 2020-08-07
 Span: 2130:1 - 2137:23
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("CreateTableSpaceStmt")]
    internal sealed class CreateTableSpaceStmt : IPg10Node
    {
        public NodeTag Type
        {
            get { return NodeTag.T_CreateTableSpaceStmt; }
        }

        public string tablespacename { get; set; }

        public RoleSpec owner { get; set; }

        public string location { get; set; }

        public IPg10Node[] options { get; set; }
    }
}
