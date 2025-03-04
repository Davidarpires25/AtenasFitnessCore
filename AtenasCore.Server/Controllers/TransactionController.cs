using AtenasCore.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtenasCore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController:Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public TransactionController(ApplicationDBContext dbContext){
            _dbContext=dbContext;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetTransactions (string id ){
            var Transaction= await _dbContext.Transactions.ToListAsync();
            if(Transaction==null){
                return NotFound();
            }
            return Ok(Transaction);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(string id ){
            var Transaction= await _dbContext.Transactions.FirstOrDefaultAsync(x=>x.AppUserId==id);
            if(Transaction==null){
                return NotFound();
            }
            return Ok(Transaction);
        }

      

        
    }



}