using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Reflection;

namespace AtenasCore.Server.Models
{
    [Table("Transactions")]
    public class Transaction{
        
        public string AppUserId {get;set;}
        public int MembershipId {get;set;}      

        public AppUser AppUser {get;set;}    
        public Membership Membership {get;set;}

        public DateTime CreatedOn {get;set;} = DateTime.Now;
        [Required]
        public required string PaymentType {get;set;}
        public ImageFileMachine Receipt {get;set;}
     

    }

}