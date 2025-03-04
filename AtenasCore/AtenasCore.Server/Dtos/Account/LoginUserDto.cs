using System.ComponentModel.DataAnnotations;

namespace AtenasCore.Server.Dtos.Account 
{
    public class LoginUserDto{
        [Required]
        public string? UserName {get;set;}
        [Required]
        public string? Password {get;set;} 
    }

}