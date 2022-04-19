using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodies.Repository;

namespace Foodies.Helper
{
    public class UserHelper : IUserHelper
    {
        private readonly IHttpContextAccessor _httpContext;

        public UserHelper(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public string getUserId()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
