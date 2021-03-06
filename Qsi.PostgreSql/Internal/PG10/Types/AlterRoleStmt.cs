/* Generated by QSI

 Date: 2020-08-12
 Span: 2439:1 - 2445:16
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("AlterRoleStmt")]
    internal class AlterRoleStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_AlterRoleStmt;

        public RoleSpec[] role { get; set; }

        public IPg10Node[] options { get; set; }

        public int? action { get; set; }
    }
}
