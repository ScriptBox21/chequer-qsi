// Generate from postgres/src/include/nodes/parsenodes.h

namespace Qsi.PostgreSql.Internal.Postgres.Nodes
{
    [PgNode("SortGroupClause")]
    internal class SortGroupClause : IPgTree
    {
        public index tleSortGroupRef { get; set; }

        public int /* oid */ eqop { get; set; }

        public int /* oid */ sortop { get; set; }

        public bool nulls_first { get; set; }

        public bool hashable { get; set; }
    }
}
