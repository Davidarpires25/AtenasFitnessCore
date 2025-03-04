
using AtenasCore.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AtenasCore.Server.Data{
    public class ApplicationDBContext:IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions):base(dbContextOptions){}

        public DbSet<Transaction> Transactions {get;set;}=null!;

        public DbSet<Membership> Memberships {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Transaction>().HasKey(x => new { x.AppUserId, x.MembershipId });
            modelBuilder.Entity<Transaction>()
                .HasOne(x=> x.AppUser)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.AppUserId);

            modelBuilder.Entity<Transaction>()
                .HasOne(x => x.Membership);
                
            List<IdentityRole> roles = new List<IdentityRole>{
                new IdentityRole { Id = "Admin", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "User", Name = "User", NormalizedName = "USER" }

            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
            
        }   

        

        

    }
}