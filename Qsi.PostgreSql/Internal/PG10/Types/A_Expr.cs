/* Generated by QSI

 Date: 2020-08-12
 Span: 271:1 - 279:9
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("A_Expr")]
    internal class A_Expr : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_A_Expr;

        public A_Expr_Kind? kind { get; set; }

        public IPg10Node[] name { get; set; }

        public IPg10Node[] lexpr { get; set; }

        public IPg10Node[] rexpr { get; set; }
    }
}
