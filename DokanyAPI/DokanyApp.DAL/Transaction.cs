using DokanyApp.BLL.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace DokanyApp.DAL
{
    public class Transaction : ITransaction
    {
        private readonly EFUnitOfWork _dbContext;
        private IDbContextTransaction dbContextTransaction;
        public Transaction(EFUnitOfWork dbContext)
        {
            _dbContext = dbContext;
        }
        public void BeginTransaction()
        {
            dbContextTransaction = _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            dbContextTransaction.Commit();
        }

        public void RollBack()
        {
            dbContextTransaction.Rollback();
        }
    }
}
