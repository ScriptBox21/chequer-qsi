/* Generated by QSI

 Date: 2020-08-12
 Span: 465:1 - 473:9
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("SortBy")]
    internal class SortBy : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_SortBy;

        public IPg10Node[] node { get; set; }

        public SortByDir? sortby_dir { get; set; }

        public SortByNulls? sortby_nulls { get; set; }

        public IPg10Node[] useOp { get; set; }
    }
}
