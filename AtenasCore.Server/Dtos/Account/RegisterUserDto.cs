using System.ComponentModel.DataAnnotations;


namespace AtenasCore.Server.Dtos
{
    public class RegisterUsertDto{
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string FirstName { get; set; }=null!;

        [Required]
        public string LastName { get; set; } =null!;
        
        public long Dni { get; set; }
        [Required]
        public int Age { get; set; }
    }

}