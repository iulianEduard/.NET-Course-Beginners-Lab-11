using Microsoft.AspNetCore.Mvc.Filters;
using Synkwise.BLL.Ports;
using Synkwise.Core.Exceptions.Role;

namespace Synkwise.API.FIlters
{
    public class ProviderAuthorizationFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        #region Attributes

        private readonly IClaimService _claimService;

        #endregion Attributes

        #region Constructor

        public ProviderAuthorizationFilter(IClaimService claimService)
        {
            _claimService = claimService;
        }

        #endregion Constructor

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User.Identity;
            string name = user.Name;

            var userRole = context.HttpContext.User.IsInRole("Provider");

            if(!userRole)
            {
                throw new RoleNotAuthorizedException("Role not authorzied for requested action!");
            }
        }
    }
}
