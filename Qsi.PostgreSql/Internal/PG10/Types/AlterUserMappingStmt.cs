/* Generated by QSI

 Date: 2020-08-07
 Span: 2266:1 - 2272:23
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("AlterUserMappingStmt")]
    internal sealed class AlterUserMappingStmt : IPg10Node
    {
        public NodeTag Type
        {
            get { return NodeTag.T_AlterUserMappingStmt; }
        }

        public RoleSpec user { get; set; }

        public string servername { get; set; }

        public IPg10Node[] options { get; set; }
    }
}
