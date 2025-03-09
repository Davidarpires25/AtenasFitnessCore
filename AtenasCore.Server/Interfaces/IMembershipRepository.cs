using AtenasCore.Server.Models;

public interface ImemberShipRepository{
    Task <Membership?> CreateAsync(Membership membership);
    Task <Membership?> UpdateAsync(int id, Membership membership);
    Task <Membership?> DeleteAsync(int id);
    Task <Membership?> GetByIdAsync(int id);
    Task <List<Membership>> GetAllAsync();
}