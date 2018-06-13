using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EpamLibrary.BLL.Interfaces;
using EpamLibrary.Contracts.Models;
using EpamLibrary.DAL.Interfaces;

namespace EpamLibrary.BLL.Services
{
    public class JournalRecordService : IJournalRecordService
    {
        private readonly IRepository<LibraryLogRecord> _logRepository;
        private readonly IUnitOfWork _unitOfWork;

        public JournalRecordService(
            IRepository<LibraryLogRecord> logRepository, 
            IUnitOfWork unitOfWork)
        {
            _logRepository = logRepository;
            _unitOfWork = unitOfWork;
        }

        public void AddRecord(LibraryLogRecord record)
        {
            _logRepository.Create(record);
            _unitOfWork.Save();
        }

        public void CloseJournalRecord(int recordId)
        {
            var record = _logRepository.GetById(recordId);
            record.ReturnTime = DateTime.UtcNow;
            _logRepository.Update(record);
            _unitOfWork.Save();
        }

        public void RemoveRecord(int recordId)
        {
            _logRepository.Delete(recordId);
            _unitOfWork.Save();
        }

        public LibraryLogRecord GetRecord(int recordId)
        {
            return _logRepository.GetById(recordId);
        }

        public IEnumerable<LibraryLogRecord> GetRecords(Expression<Func<LibraryLogRecord, bool>> predicate = null, int @from = 0, int count = 10)
        {
            var log = _logRepository.Get(predicate);

            if (log == null)
                return null;

            if (from > log.Count())
                throw new ArgumentException();

            if (log.Count() - from < count)
                count = log.Count() - from;

            return log.Skip(from).Take(count).ToList();
        }
    }
}
