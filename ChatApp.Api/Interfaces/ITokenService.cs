using ChatApp.Core.Entities;

namespace ChatApp.Api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User  user);
    }
}
