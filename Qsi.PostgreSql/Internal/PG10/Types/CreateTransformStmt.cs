/* Generated by QSI

 Date: 2020-08-12
 Span: 3269:1 - 3277:22
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("CreateTransformStmt")]
    internal class CreateTransformStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_CreateTransformStmt;

        public bool? replace { get; set; }

        public TypeName[] type_name { get; set; }

        public string lang { get; set; }

        public ObjectWithArgs[] fromsql { get; set; }

        public ObjectWithArgs[] tosql { get; set; }
    }
}