/* Generated by QSI

 Date: 2020-08-12
 Span: 475:1 - 482:15
 File: src/postgres/include/nodes/primnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("NamedArgExpr")]
    internal class NamedArgExpr : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_NamedArgExpr;

        public IPg10Node xpr { get; set; }

        public IPg10Node[] arg { get; set; }

        public string name { get; set; }

        public int? argnumber { get; set; }
    }
}
