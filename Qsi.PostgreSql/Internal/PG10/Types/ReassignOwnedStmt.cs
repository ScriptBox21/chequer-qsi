/* Generated by QSI

 Date: 2020-08-12
 Span: 3329:1 - 3334:20
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("ReassignOwnedStmt")]
    internal class ReassignOwnedStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_ReassignOwnedStmt;

        public IPg10Node[] roles { get; set; }

        public RoleSpec[] newrole { get; set; }
    }
}
