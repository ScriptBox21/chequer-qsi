/* Generated by QSI

 Date: 2020-08-12
 Span: 765:1 - 773:13
 File: src/postgres/include/nodes/primnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("FieldStore")]
    internal class FieldStore : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_FieldStore;

        public IPg10Node xpr { get; set; }

        public IPg10Node arg { get; set; }

        public IPg10Node[] newvals { get; set; }

        public IPg10Node[] fieldnums { get; set; }

        public uint? resulttype { get; set; }
    }
}
