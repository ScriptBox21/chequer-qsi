/* Generated by QSI

 Date: 2020-08-07
 Span: 2245:1 - 2250:25
 File: src/postgres/include/nodes/parsenodes.h

*/

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    internal sealed class CreateForeignTableStmt
    {
        public CreateStmt @base { get; set; }

        public string servername { get; set; }

        public IPg10Node[] options { get; set; }
    }
}
