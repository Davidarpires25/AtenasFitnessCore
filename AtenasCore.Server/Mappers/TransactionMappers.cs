
using AtenasCore.Server.Models;

namespace AtenasCore.Server.Mappers
{
    public static class TransactionMappers{

        public static Transaction  ToTransaction(this CreateTransactionDto transactionDto){

            return new Transaction {
                AppUserId=transactionDto.AppUserId,
                MembershipId=transactionDto.MembershipId,
                PaymentType=transactionDto.PaymentType,
                CreatedOn=DateTime.Now
                        
            };

        }

        public static TransactionDto  ToTransactionDto(this Transaction transaction){

            return new TransactionDto{
                AppUserId=transaction.AppUserId,
                MembershipId=transaction.MembershipId,
                CreatedOn=transaction.CreatedOn,
                PaymentType=transaction.PaymentType,
                Receipt=transaction.Receipt

            };
        }
    }
    

}