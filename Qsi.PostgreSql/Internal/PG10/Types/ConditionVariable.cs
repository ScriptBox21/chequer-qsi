/* Generated by QSI

 Date: 2020-08-12
 Span: 28:1 - 32:20
 File: src/postgres/include/storage/condition_variable.h

*/

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    internal class ConditionVariable
    {
        public byte? mutex { get; set; }

        public proclist_head wakeup { get; set; }
    }
}
