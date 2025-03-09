
using AtenasCore.Server.Data;
using AtenasCore.Server.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtenasCore.Server.Mappers;
using AtenasCore.Server.Models;
namespace AtenasCore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController:Controller {
        private readonly ImemberShipRepository _membershipRepository;
        

        public MembershipController(ApplicationDBContext dBContext,ImemberShipRepository membershipRepository){
            _membershipRepository= membershipRepository;
            
           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMembershipById([FromRoute] int id){
            if(!ModelState.IsValid){
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var Model= await _membershipRepository.GetByIdAsync(id);

            return StatusCode(StatusCodes.Status200OK,Model);

        }

        [HttpPost]
        public async Task<IActionResult> SetMembership ([FromBody] CreateMembershipDto membershipDto){
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var membershipModel = membershipDto.ToMembership();
            await _membershipRepository.CreateAsync(membershipModel);

            
            return CreatedAtAction(nameof(GetMembershipById), new { id = membershipModel.Id }, membershipModel.ToMembershipDto());

        }


        [HttpGet]
        public async Task<IActionResult> GetMemberships (){
            if(!ModelState.IsValid){
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var Memberships= await _membershipRepository.GetAllAsync();
            var MembershipsDto= Memberships.Select(m=>m.ToMembershipDto()).ToList();

            return StatusCode(StatusCodes.Status200OK,MembershipsDto);



        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembership([FromRoute] int id){
            if(!ModelState.IsValid){
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var model= await _membershipRepository.DeleteAsync(id);

            if(model==null){
                return NotFound();
            }
            return StatusCode(StatusCodes.Status204NoContent);


        }

        [HttpPut("{id}")]
         public async Task<IActionResult> updateMembership([FromRoute] int id,[FromBody] CreateMembershipDto membershipDto){
            if(!ModelState.IsValid){
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var membershipUpdate= membershipDto.ToMembership();

            var model= await _membershipRepository.UpdateAsync(id,membershipUpdate);

            if(model==null){
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK,model.ToMembershipDto());


        }
        


    }


}