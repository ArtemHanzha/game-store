using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EpamLibrary.Contracts.Models;

namespace EpamLibrary.BLL.Interfaces
{
    public interface IJournalRecordService
    {
        void AddRecord(LibraryLogRecord record);

        void CloseJournalRecord(int recordId);

        void RemoveRecord(int recordId);

        LibraryLogRecord GetRecord(int recordId);

        IEnumerable<LibraryLogRecord> GetRecords(Expression<Func<LibraryLogRecord, bool>> predicate = null, int from = 0, int count = 10);

        void Edit(LibraryLogRecord record);
    }
}