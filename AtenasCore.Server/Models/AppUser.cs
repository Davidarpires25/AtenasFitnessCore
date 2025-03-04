using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AtenasCore.Server.Models{

   public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres.")]
        public string FirstName { get; set; }=null!;
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 50 caracteres.")]
        public string LastName { get; set; } =null!;
        [Required]
        [Range(10000000, 99999999, ErrorMessage = "El DNI debe tener exactamente 8 dígitos.")]
        public long Dni { get; set; }
        [Required]
        public int Age { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
      
    }
}