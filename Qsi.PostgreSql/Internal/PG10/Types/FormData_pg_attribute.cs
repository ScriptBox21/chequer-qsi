/* Generated by QSI

 Date: 2020-08-07
 Span: 36:1 - 171:24
 File: src/postgres/include/catalog/pg_attribute.h

*/

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    internal sealed class FormData_pg_attribute
    {
        public uint attrelid { get; set; }

        public nameData attname { get; set; }

        public uint atttypid { get; set; }

        public int attstattarget { get; set; }

        public short attlen { get; set; }

        public short attnum { get; set; }

        public int attndims { get; set; }

        public int attcacheoff { get; set; }

        public int atttypmod { get; set; }

        public bool attbyval { get; set; }

        public char attstorage { get; set; }

        public char attalign { get; set; }

        public bool attnotnull { get; set; }

        public bool atthasdef { get; set; }

        public char attidentity { get; set; }

        public bool attisdropped { get; set; }

        public bool attislocal { get; set; }

        public int attinhcount { get; set; }

        public uint attcollation { get; set; }
    }
}
