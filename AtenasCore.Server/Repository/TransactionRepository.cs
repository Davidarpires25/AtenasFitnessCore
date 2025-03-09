using System.Data.Common;
using AtenasCore.Server.Data;
using AtenasCore.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AtenasCore.Server.Repository
{
    public class TransactionRepository : ItransactionRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public TransactionRepository(ApplicationDBContext dbContext){
            _dbContext=dbContext;
        }

        public async Task<Transaction?> CreateAsync(Transaction transaction)
        {
            await _dbContext.Transactions.AddAsync(transaction);
            await _dbContext.SaveChangesAsync();

            return transaction;
        }

        public async Task<Transaction?> DeleteTransaction(int id)
        {
            var TransactionModel= await _dbContext.Transactions.FirstOrDefaultAsync(transaction => transaction.Id==id);
            if(TransactionModel==null){
                return null;
            }
            _dbContext.Remove(TransactionModel);
            await _dbContext.SaveChangesAsync();

            return TransactionModel;


        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _dbContext.Transactions.ToListAsync();
        }   
        
        
        public async Task<Transaction?> GetByIdAsync(int id){
            var TransactionModel= await _dbContext.Transactions.FirstOrDefaultAsync(x=> x.Id==id);
            if(TransactionModel==null){
                return null;
            }
            return TransactionModel;

        }
        
            
    
    }

}