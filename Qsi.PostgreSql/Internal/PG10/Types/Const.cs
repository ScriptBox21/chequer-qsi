/* Generated by QSI

 Date: 2020-08-12
 Span: 189:1 - 204:8
 File: src/postgres/include/nodes/primnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("Const")]
    internal class Const : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_Const;

        public IPg10Node xpr { get; set; }

        public uint? consttype { get; set; }

        public int? consttypmod { get; set; }

        public uint? constcollid { get; set; }

        public int? constlen { get; set; }

        public uint? constvalue { get; set; }

        public bool? constisnull { get; set; }

        public bool? constbyval { get; set; }
    }
}
