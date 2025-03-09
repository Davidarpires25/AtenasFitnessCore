using AtenasCore.Server.Dtos;
using AtenasCore.Server.Models;

namespace AtenasCore.Server.Mappers
{
    public static class MembershipMappers{

          public static MembershipDto ToMembershipDto(this Membership membership){
            return new MembershipDto{
                Id= membership.Id,
                Name=membership.Name,
                Price= membership.Price,
                Duration= membership.Duration
            };

        }

        public static Membership ToMembership(this CreateMembershipDto membershipDto){
            return new Membership{
                Name=membershipDto.Name,
                Price= membershipDto.Price,
                Duration= membershipDto.Duration
            };

        }

    }


}