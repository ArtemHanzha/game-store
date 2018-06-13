using EpamLibrary.Contracts.Enums;
using EpamLibrary.Contracts.Models.MongoDB;

namespace EpamLibrary.DAL.Interfaces
{
    public interface ILogger
    {
        void WriteLog(LogInfo logInfo, LogKind type);
    }
}