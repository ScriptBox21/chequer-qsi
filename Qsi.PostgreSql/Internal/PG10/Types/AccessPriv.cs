/* Generated by QSI

 Date: 2020-08-12
 Span: 1893:1 - 1898:13
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("AccessPriv")]
    internal class AccessPriv : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_AccessPriv;

        public string priv_name { get; set; }

        public IPg10Node[] cols { get; set; }
    }
}
