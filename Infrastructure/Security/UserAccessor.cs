using Microsoft.AspNetCore.Http;

using System;
using System.Security.Claims;

namespace Infrastructure.Security
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserAccessor(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            Id = Convert.ToInt32(_contextAccessor.HttpContext?.User?.FindFirstValue(claimType: ClaimTypes.PrimarySid));
            UserName = _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Actor);
            
        }
        public int Id { get; set; }

        public string UserName { get; set; }
    }
}
