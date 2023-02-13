using Infrastructure.Common;
using Infrastructure.IServices.IAuthService;
using Infrastructure.Security;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Models;
using Models.Auth;

using Persistance;

using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Infrastructure.Services.AuthServices
{
    public class LoginService : ILoginService
    {
        private readonly GigaTechContext _context;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly ILogger<LoginService> _logger;
        IUserAccessor _userAccessor;

        public LoginService(GigaTechContext context, ITokenGenerator tokenGenerator, ILogger<LoginService> logger, IUserAccessor userAccessor)
        {
            _context = context;
            _tokenGenerator = tokenGenerator;
            _logger = logger;
            _userAccessor = userAccessor;
        }

        public async Task<User> SignIn(Login login)
        {

            try
            {
                var registeredUser = await _context.Register.AnyAsync(user => user.UserName == login.UserName);

                var registeredPassword = await _context.Register.AnyAsync(user => user.Password == login.Password);

                if (!registeredUser || !registeredPassword)

                    throw new RestException(HttpStatusCode.NotFound, "User Name or Password Not Found/Matched.");

                if (registeredUser && registeredPassword)
                {
                    var registerUser = await _context.Register.Where(u => u.UserName == login.UserName).FirstOrDefaultAsync();

                    var user = new User
                    {
                        Id = registerUser.Id,
                        UserName = registerUser.UserName
                    };

                    _userAccessor.Id = registerUser.Id;
                    _userAccessor.UserName = registerUser.UserName;


                    return new User
                    {
                        Id = registerUser.Id,
                        UserName = registerUser.UserName,
                        Token = _tokenGenerator.CreateToken(registerUser)
                    };
                }
                throw new RestException(HttpStatusCode.BadRequest);
            }
            catch (Exception e)
            {
                throw new RestException(HttpStatusCode.BadRequest, e.Message);
            }
            
        }

        public async Task SignOut()
        {
            throw new NotImplementedException();
        }
    }
}
