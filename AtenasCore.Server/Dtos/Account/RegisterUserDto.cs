using System.ComponentModel.DataAnnotations;


namespace AtenasCore.Server.Dtos
{
    public class RegisterRequestDto{
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }

}