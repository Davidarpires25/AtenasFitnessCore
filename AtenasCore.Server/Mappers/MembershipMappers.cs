using AtenasCore.Server.Dtos;
using AtenasCore.Server.Models;

namespace AtenasCore.Server.Mappers
{
    public static class membershipMappers{

          public static MembershipDto ToCreateDtoFromMembership(this Membership membership){
            return new MembershipDto{
                Id= membership.Id,
                Name=membership.Name,
                Price= membership.Price,
                Duration= membership.Duration
            };

        }

        public static Membership ToMembershipFromCreateDto(this CreateMembershipDto membershipDto){
            return new Membership{
                Name=membershipDto.Name,
                Price= membershipDto.Price,
                Duration= membershipDto.Duration
            };

        }

    }


}