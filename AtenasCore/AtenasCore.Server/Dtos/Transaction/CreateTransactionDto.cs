using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace AtenasCore.Server.Models
{
    public class CreateTransactionDto{
        
        public string AppUserId {get;set;}
        public int MembershipId {get;set;}      
        public required string PaymentType {get;set;}
    
     
     
    }

}