/* Generated by QSI

 Date: 2020-08-12
 Span: 788:1 - 797:14
 File: src/postgres/include/nodes/primnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("RelabelType")]
    internal class RelabelType : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_RelabelType;

        public IPg10Node xpr { get; set; }

        public IPg10Node arg { get; set; }

        public uint? resulttype { get; set; }

        public int? resulttypmod { get; set; }

        public uint? resultcollid { get; set; }

        public CoercionForm? relabelformat { get; set; }
    }
}
