using Microsoft.AspNetCore.Mvc.Filters;
using Synkwise.Core.Exceptions.Role;

namespace Synkwise.API.FIlters
{
    public class FacilityAuthorizationFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User.Identity;
            string name = user.Name;

            var userInRole = context.HttpContext.User.IsInRole("Provider");

            if(!userInRole)
            {
                userInRole = context.HttpContext.User.IsInRole("Resident Manager");

                if(!userInRole)
                {
                    userInRole = context.HttpContext.User.IsInRole("Nurse Delegator");

                    if(!userInRole)
                    {
                        userInRole = context.HttpContext.User.IsInRole("Caregiver");

                        if(!userInRole)
                        {
                            throw new RoleNotAuthorizedException("Role not authorzied for requested action!");
                        }
                    }
                }
            }

        }
    }
}
