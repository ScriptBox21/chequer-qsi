/* Generated by QSI

 Date: 2020-08-07
 Span: 3041:1 - 3046:23
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("AlterDatabaseSetStmt")]
    internal sealed class AlterDatabaseSetStmt : IPg10Node
    {
        public NodeTag Type
        {
            get { return NodeTag.T_AlterDatabaseSetStmt; }
        }

        public string dbname { get; set; }

        public VariableSetStmt setstmt { get; set; }
    }
}
