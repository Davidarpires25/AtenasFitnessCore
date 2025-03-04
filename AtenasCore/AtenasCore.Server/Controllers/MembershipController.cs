
using AtenasCore.Server.Data;
using AtenasCore.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtenasCore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController:Controller {
        private readonly ApplicationDBContext _dbContext;

        public MembershipController(ApplicationDBContext dBContext){
            _dbContext=dBContext;
        }

        [HttpPost]
        public async Task<IActionResult> setMembership ([FromBody] string name, decimal price, int duration){
            Membership membership= new Membership{
                Name=name,
                Price=price,
                Duration=duration
            };

            var model= await _dbContext.Memberships.AddAsync(membership);
            await _dbContext.SaveChangesAsync();

            if(model==null){
                return NotFound();
            }
            return Ok(model.ToString());

        }
        [HttpGet]
        public async Task<IActionResult> getMemberships (){
        var models= await _dbContext.Memberships.ToListAsync();

        if(models==null){
            return NotFound();
        }
        return Ok(models);


        }

    
        


    }


}