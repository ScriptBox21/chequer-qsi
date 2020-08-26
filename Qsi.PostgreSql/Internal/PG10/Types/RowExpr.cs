/* Generated by QSI

 Date: 2020-08-12
 Span: 983:1 - 1001:10
 File: src/postgres/include/nodes/primnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("RowExpr")]
    internal class RowExpr : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_RowExpr;

        public IPg10Node xpr { get; set; }

        public IPg10Node[] args { get; set; }

        public uint? row_typeid { get; set; }

        public CoercionForm? row_format { get; set; }

        public IPg10Node[] colnames { get; set; }
    }
}