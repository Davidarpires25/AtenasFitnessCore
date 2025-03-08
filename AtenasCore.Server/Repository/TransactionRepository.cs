using AtenasCore.Server.Models;

namespace AtenasCore.Server.Repository
{
    public class TransactionRepository : ItransactionRepository
    {
        public Task<Transaction?> CreateAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Task<Transaction?> DeleteTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transaction?>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Transaction?> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Transaction?> UpdateAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }

}