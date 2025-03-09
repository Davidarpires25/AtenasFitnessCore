using AtenasCore.Server.Models;

public interface ItransactionRepository{

    Task <Transaction?> GetByIdAsync(int id);
    Task <List<Transaction>> GetAllAsync();
    Task <Transaction?> CreateAsync(Transaction transaction);
    Task <Transaction?> DeleteTransaction(int id);

   
}