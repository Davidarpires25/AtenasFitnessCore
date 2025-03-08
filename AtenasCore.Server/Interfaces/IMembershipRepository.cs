using AtenasCore.Server.Models;

interface ImemberShipRepository{
    Task <Membership?> CreateAsync(Membership membership);
    Task <Membership?> UpdateAsync(int id,Membership membership);
    Task <Membership?> DeleteMembership(int id);
}