/* Generated by QSI

 Date: 2020-08-12
 Span: 2339:1 - 2345:15
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("CreateAmStmt")]
    internal class CreateAmStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_CreateAmStmt;

        public string amname { get; set; }

        public IPg10Node[] handler_name { get; set; }

        public char? amtype { get; set; }
    }
}