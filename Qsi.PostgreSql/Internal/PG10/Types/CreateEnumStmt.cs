/* Generated by QSI

 Date: 2020-08-12
 Span: 2954:1 - 2959:17
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("CreateEnumStmt")]
    internal class CreateEnumStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_CreateEnumStmt;

        public IPg10Node[] typeName { get; set; }

        public IPg10Node[] vals { get; set; }
    }
}
