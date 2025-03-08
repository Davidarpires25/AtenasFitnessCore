using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;


public enum PaymentType
{
    [Display(Name = "Transferencia")]
    Transferencia,

    [Display(Name = "EFectivo")]
    EFectivo,

    
}

namespace AtenasCore.Server.Models
{
    [Table("Transactions")]
    public class Transaction{
        
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string AppUserId {get;set;}
        public int MembershipId {get;set;}      

        public AppUser AppUser {get;set;}    
        public Membership Membership {get;set;}

        public DateTime CreatedOn {get;set;} = DateTime.Now;
        [Required]
        public required PaymentType PaymentType {get;set;}

        [Required]
        public ImageFileMachine Receipt {get;set;}
     
    }

}