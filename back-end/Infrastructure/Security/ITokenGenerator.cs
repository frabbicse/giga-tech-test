using Models.Auth;

namespace Infrastructure.Security
{
    public interface ITokenGenerator
    {
        string CreateToken(Register user);
    }
}
