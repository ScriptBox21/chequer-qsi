/* Generated by QSI

 Date: 2020-08-12
 Span: 933:1 - 939:15
 File: src/postgres/include/nodes/primnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("CaseTestExpr")]
    internal class CaseTestExpr : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_CaseTestExpr;

        public IPg10Node xpr { get; set; }

        public uint? typeId { get; set; }

        public int? typeMod { get; set; }

        public uint? collation { get; set; }
    }
}
