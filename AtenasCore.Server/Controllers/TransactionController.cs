using AtenasCore.Server.Data;
using AtenasCore.Server.Mappers;
using AtenasCore.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AtenasCore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController:Controller
    {
        private readonly ItransactionRepository _transactionRepository;

     

        public TransactionController(ItransactionRepository transactionRepository){
            _transactionRepository= transactionRepository;

        }
        
        [HttpGet]
        public async Task<IActionResult> GetTransactions (){
            if(!ModelState.IsValid){
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var Transactions= await _transactionRepository.GetAllAsync();
            var TransactionsDto=Transactions.Select(t => t.ToTransactionDto()).ToList();
            
            return StatusCode(StatusCodes.Status200OK,TransactionsDto);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(int id ){
            if(!ModelState.IsValid){
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var model= await _transactionRepository.GetByIdAsync(id);
            if(model==null){
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status200OK,model.ToTransactionDto());

        }

        [HttpPost]
        public async Task<IActionResult> SetTransaction([FromBody] CreateTransactionDto transactionDto){
            if(!ModelState.IsValid){
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var modelTransaction= transactionDto.ToTransaction();
            await _transactionRepository.CreateAsync(modelTransaction);
        
            return CreatedAtAction(nameof(GetTransactionById), new { id = modelTransaction.Id }, modelTransaction.ToTransactionDto());

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTransaction([FromRoute] int id){
            if(!ModelState.IsValid){
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var Transaction = await _transactionRepository.DeleteTransaction(id);

             if (Transaction == null) {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status204NoContent);

        }

      

        
    }



}