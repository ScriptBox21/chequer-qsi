/* Generated by QSI

 Date: 2020-08-07
 Span: 1400:1 - 1406:20
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("TriggerTransition")]
    internal sealed class TriggerTransition : IPg10Node
    {
        public NodeTag Type
        {
            get { return NodeTag.T_TriggerTransition; }
        }

        public string name { get; set; }

        public bool isNew { get; set; }

        public bool isTable { get; set; }
    }
}
