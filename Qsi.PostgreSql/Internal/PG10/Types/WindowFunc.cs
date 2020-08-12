/* Generated by QSI

 Date: 2020-08-12
 Span: 352:1 - 365:13
 File: src/postgres/include/nodes/primnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("WindowFunc")]
    internal class WindowFunc : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_WindowFunc;

        public IPg10Node xpr { get; set; }

        public uint? winfnoid { get; set; }

        public uint? wintype { get; set; }

        public uint? wincollid { get; set; }

        public uint? inputcollid { get; set; }

        public IPg10Node[] args { get; set; }

        public IPg10Node aggfilter { get; set; }

        public uint? winref { get; set; }

        public bool? winstar { get; set; }

        public bool? winagg { get; set; }
    }
}
