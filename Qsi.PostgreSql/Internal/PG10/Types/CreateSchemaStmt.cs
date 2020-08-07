/* Generated by QSI

 Date: 2020-08-07
 Span: 1671:1 - 1678:19
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("CreateSchemaStmt")]
    internal sealed class CreateSchemaStmt : IPg10Node
    {
        public NodeTag Type
        {
            get { return NodeTag.T_CreateSchemaStmt; }
        }

        public string schemaname { get; set; }

        public RoleSpec authrole { get; set; }

        public IPg10Node[] schemaElts { get; set; }

        public bool if_not_exists { get; set; }
    }
}
