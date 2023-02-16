using Infrastructure.Common;
using Infrastructure.IServices.IAuthService;
using Infrastructure.Security;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Models;
using Models.Auth;

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        ILoginService _loginService;
        IRegisterService _registerService;
     
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILoginService loginService, IRegisterService registerService,ILogger<AuthController>logger)
        {
            _loginService = loginService;
            _registerService = registerService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(Login login)
        {
            try
            {
                _logger.LogInformation($"Logged Info : {login.UserName},{login.Password} ");

                return await _loginService.SignIn(login);
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception : {e.Message}");
                throw new RestException(HttpStatusCode.NotFound, e.Message);
            }
            
        }

        [HttpPost("register")]
        public async Task<ActionResult<bool>> Register ([FromBody]Register register)
        {
            try
            {
                _logger.LogInformation($"Register Info : {register.UserName},{register.Password} ,{ register.PhoneNo},{register.EmailId} ");
                return await _registerService.Register(register);
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception : {e.Message}");
                throw new RestException(HttpStatusCode.NotFound, e.Message);
            }
           
        }

        [HttpGet("registereduser")]
        public async Task<ActionResult<List<Register>>> RegisteredUser()
        {
            return await _registerService.RegisteredUser();
        }
    }
}
