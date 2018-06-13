using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamLibrary.DAL.Context;
using EpamLibrary.DAL.Interfaces;

namespace EpamLibrary.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _dbContext;

        public UnitOfWork(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
