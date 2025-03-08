using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Reflection;

namespace AtenasCore.Server.Models
{
    public class TransactionDto{
        
        
        public string AppUserId {get;set;}
        public int MembershipId {get;set;}      
        public DateTime CreatedOn {get;set;}
        public required PaymentType PaymentType {get;set;}
        public ImageFileMachine Receipt {get;set;}
     
    }

}