/* Generated by QSI

 Date: 2020-08-12
 Span: 98:1 - 124:12
 File: src/postgres/include/lib/simplehash.h

*/

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    internal class tuplehash_hash
    {
        public uint? size { get; set; }

        public uint? members { get; set; }

        public uint? sizemask { get; set; }

        public uint? grow_threshold { get; set; }

        public TupleHashEntryData[] data { get; set; }

        public MemoryContext ctx { get; set; }

        public object[] private_data { get; set; }
    }
}