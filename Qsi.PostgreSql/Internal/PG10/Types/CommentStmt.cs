/* Generated by QSI

 Date: 2020-08-07
 Span: 2601:1 - 2607:14
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("CommentStmt")]
    internal sealed class CommentStmt : IPg10Node
    {
        public NodeTag Type
        {
            get { return NodeTag.T_CommentStmt; }
        }

        public ObjectType objtype { get; set; }

        public IPg10Node @object { get; set; }

        public string comment { get; set; }
    }
}
