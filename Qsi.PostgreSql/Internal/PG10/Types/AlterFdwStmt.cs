/* Generated by QSI

 Date: 2020-08-12
 Span: 2207:1 - 2213:15
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("AlterFdwStmt")]
    internal class AlterFdwStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_AlterFdwStmt;

        public string fdwname { get; set; }

        public IPg10Node[] func_options { get; set; }

        public IPg10Node[] options { get; set; }
    }
}
