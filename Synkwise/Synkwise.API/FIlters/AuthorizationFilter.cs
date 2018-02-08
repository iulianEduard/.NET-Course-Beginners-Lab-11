using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Synkwise.API.FIlters
{
    public class AuthorizationFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User.Identity;

            string name = user.Name;

            var userAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;

            if (!userAuthenticated)
            {

            }
        }
    }
}
