using System.ComponentModel.DataAnnotations.Schema;

namespace AtenasCore.Server.Dtos
{
    public class CreateMembershipDto{
        public required string Name {get;set;}
        [Column(TypeName = "decimal(5,0)")]
        public decimal Price {get;set;}
        public int Duration {get;set;}
    }

}