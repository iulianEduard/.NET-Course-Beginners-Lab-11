using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Synkwise.Core.Exceptions.Account;
using Synkwise.Core.Exceptions.Claim;
using Synkwise.Core.Exceptions.Provider;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Synkwise.API.Controllers
{
    public class BaseController : Controller
    {
        #region Public Methods

        public string GetCurrentUserEmail()
        {
            string userEmail = GetClaimValue(ClaimTypes.Email);

            return userEmail;
        }

        public string GetCurrentUserRole()
        {
            string userRole = GetClaimValue(ClaimTypes.Role);

            return userRole;
        }

        public string GetErrorMessageFromModelState(IEnumerable<ModelError> errorModelCollection)
        {
            StringBuilder errorMessage = new StringBuilder();

            foreach (var error in errorModelCollection)
            {
                errorMessage.AppendLine(error.ErrorMessage);
            }

            return errorMessage.ToString();
        }

        #endregion Public Methods

        #region Protected Methods

        protected string GetErrorMessage()
        {
            IEnumerable<ModelError> errorModelCollection = ModelState.Values.SelectMany(error => error.Errors);
            string errorMessage = GetErrorMessageFromModelState(errorModelCollection);

            return errorMessage;
        }

        #endregion ProtectedMethods

        #region Private Methods

        private ClaimsPrincipal GetCurrentUser()
        {
            var currentUser = HttpContext.User;

            if (!currentUser.Identity.IsAuthenticated)
            {
                throw new AccountBadRequestException("User not authenticated!");
            }

            return currentUser;
        }

        private string GetClaimValue(string claimType)
        {
            var currentUser = GetCurrentUser();
            var claimValue = string.Empty;

            if (currentUser.HasClaim(c => c.Type == claimType))
            {
                claimValue = currentUser.Claims.FirstOrDefault(c => c.Type == claimType).Value;

                if (string.IsNullOrEmpty(claimValue))
                {
                    throw new ClaimInternalServerErrorException("Missing value from claim request!");
                }
            }
            else
            {
                throw new ClaimNotFoundException("Missing claim from request!");
            }

            return claimValue;
        }

        #endregion Private Methods
    }
}
