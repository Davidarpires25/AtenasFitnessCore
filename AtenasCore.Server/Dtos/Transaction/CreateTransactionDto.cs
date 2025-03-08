using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.ComponentModel.DataAnnotations;


namespace AtenasCore.Server.Models
{
    public class CreateTransactionDto{
        
        public string AppUserId {get;set;}
        public int MembershipId {get;set;}      
        public required PaymentType PaymentType {get;set;}
        
    
     
     
    }

}