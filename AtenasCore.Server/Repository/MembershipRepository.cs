using AtenasCore.Server.Data;
using AtenasCore.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AtenasCore.Server.Repository
{
    public class MembershipRepository : ImemberShipRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public MembershipRepository(ApplicationDBContext dbcontext){
            _dbContext=dbcontext;
        }

        public async Task<Membership?> CreateAsync(Membership membership)
        {
            await _dbContext.Memberships.AddAsync(membership);
            await _dbContext.SaveChangesAsync();

            return membership;


        }

        public async Task<Membership?> DeleteMembership(int id)
        {
            var model= await _dbContext.Memberships.FirstOrDefaultAsync(membership => membership.Id==id);
            if(model==null){
                return null;
            }
            _dbContext.Memberships.Remove(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<Membership?> UpdateAsync(int id,Membership membershipUpdate)
        {
            
            var membershipmodel= await _dbContext.Memberships.FirstOrDefaultAsync(membership => membership.Id==id);
            if(membershipmodel==null){
                return null;
            }
            membershipmodel.Name=membershipUpdate.Name;
            membershipmodel.Price=membershipUpdate.Price;
            membershipmodel.Duration=membershipUpdate.Duration;
            
            await _dbContext.SaveChangesAsync();
            return membershipmodel;


        }
    }

}