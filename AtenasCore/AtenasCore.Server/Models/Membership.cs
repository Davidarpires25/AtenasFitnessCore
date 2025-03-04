using System.ComponentModel.DataAnnotations.Schema;

namespace AtenasCore.Server.Models
{
    [Table("Memberships")]
    public class Membership {
        public int Id {get;set;}
        public required string Name {get;set;}
        [Column(TypeName = "decimal(5,0)")]
        public decimal Price {get;set;}
        public int Duration {get;set;}


    }

}