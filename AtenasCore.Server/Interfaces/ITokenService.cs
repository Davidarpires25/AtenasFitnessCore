
using AtenasCore.Server.Models;

namespace AtenasCore.Server.interfaces
{
    public interface ITokenService{
        public string createToken(AppUser user);
    }

}