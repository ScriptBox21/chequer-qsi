/* Generated by QSI

 Date: 2020-08-07
 Span: 214:1 - 238:14
 File: src/postgres/include/nodes/plannodes.h

*/

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    internal sealed class ModifyTable
    {
        public Plan plan { get; set; }

        public CmdType operation { get; set; }

        public bool canSetTag { get; set; }

        public uint nominalRelation { get; set; }

        public IPg10Node[] partitioned_rels { get; set; }

        public IPg10Node[] resultRelations { get; set; }

        public int resultRelIndex { get; set; }

        public int rootResultRelIndex { get; set; }

        public IPg10Node[] plans { get; set; }

        public IPg10Node[] withCheckOptionLists { get; set; }

        public IPg10Node[] returningLists { get; set; }

        public IPg10Node[] fdwPrivLists { get; set; }

        public Bitmapset fdwDirectModifyPlans { get; set; }

        public IPg10Node[] rowMarks { get; set; }

        public int epqParam { get; set; }

        public OnConflictAction onConflictAction { get; set; }

        public IPg10Node[] arbiterIndexes { get; set; }

        public IPg10Node[] onConflictSet { get; set; }

        public IPg10Node onConflictWhere { get; set; }

        public uint exclRelRTI { get; set; }

        public IPg10Node[] exclRelTlist { get; set; }
    }
}
