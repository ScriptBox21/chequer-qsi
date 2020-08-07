/* Generated by QSI

 Date: 2020-08-07
 Span: 2998:1 - 3007:11
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("ViewStmt")]
    internal sealed class ViewStmt : IPg10Node
    {
        public NodeTag Type
        {
            get { return NodeTag.T_ViewStmt; }
        }

        public RangeVar view { get; set; }

        public IPg10Node[] aliases { get; set; }

        public IPg10Node query { get; set; }

        public bool replace { get; set; }

        public IPg10Node[] options { get; set; }

        public ViewCheckOption withCheckOption { get; set; }
    }
}
