using AtenasCore.Server.Models;

interface ItransactionRepository{

    Task <Transaction?> GetByIdAsync(string id);
    Task <List<Transaction?>> GetAllAsync();
    Task <Transaction?> CreateAsync(Transaction transaction);
    Task <Transaction?> UpdateAsync(Transaction transaction);
    Task <Transaction?> DeleteTransaction(Transaction transaction);

   
}