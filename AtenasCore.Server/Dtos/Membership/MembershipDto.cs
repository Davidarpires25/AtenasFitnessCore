using System.ComponentModel.DataAnnotations.Schema;

namespace AtenasCore.Server.Models
{
    public class MembershipDto {

        public int Id {get;set;}
        public required string Name {get;set;}
        public decimal Price {get;set;}
        public int Duration {get;set;}


    }

}