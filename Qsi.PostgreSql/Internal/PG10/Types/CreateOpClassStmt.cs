/* Generated by QSI

 Date: 2020-08-12
 Span: 2518:1 - 2527:20
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("CreateOpClassStmt")]
    internal class CreateOpClassStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_CreateOpClassStmt;

        public IPg10Node[] opclassname { get; set; }

        public IPg10Node[] opfamilyname { get; set; }

        public string amname { get; set; }

        public TypeName[] datatype { get; set; }

        public IPg10Node[] items { get; set; }

        public bool? isDefault { get; set; }
    }
}
