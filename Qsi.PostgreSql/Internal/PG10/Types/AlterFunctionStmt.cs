/* Generated by QSI

 Date: 2020-08-12
 Span: 2768:1 - 2773:20
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("AlterFunctionStmt")]
    internal class AlterFunctionStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_AlterFunctionStmt;

        public ObjectWithArgs[] func { get; set; }

        public IPg10Node[] actions { get; set; }
    }
}
