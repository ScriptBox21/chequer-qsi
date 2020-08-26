/* Generated by QSI

 Date: 2020-08-12
 Span: 2490:1 - 2499:13
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("DefineStmt")]
    internal class DefineStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_DefineStmt;

        public ObjectType? kind { get; set; }

        public bool? oldstyle { get; set; }

        public IPg10Node[] defnames { get; set; }

        public IPg10Node[] args { get; set; }

        public IPg10Node[] definition { get; set; }

        public bool? if_not_exists { get; set; }
    }
}