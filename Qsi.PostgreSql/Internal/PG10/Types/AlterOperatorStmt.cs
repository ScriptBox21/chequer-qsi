/* Generated by QSI

 Date: 2020-08-12
 Span: 2858:1 - 2863:20
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("AlterOperatorStmt")]
    internal class AlterOperatorStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_AlterOperatorStmt;

        public ObjectWithArgs[] opername { get; set; }

        public IPg10Node[] options { get; set; }
    }
}