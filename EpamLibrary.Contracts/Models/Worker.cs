using System;
using EpamLibrary.Contracts.Enums;
using EpamLibrary.Contracts.Models.Abstracts;

namespace EpamLibrary.Contracts.Models
{
    public class Worker : AbstractUser
    {
        public string WorkerNumber { get; set; }

        public DateTime HiringDate { get; set; }

        public WorkerType WorkerType { get; set; }
    }
}
