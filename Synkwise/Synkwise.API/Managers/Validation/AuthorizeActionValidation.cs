using Microsoft.AspNetCore.Http;
using Synkwise.BLL.Ports;
using Synkwise.Core.Exceptions.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Synkwise.API.Managers.Validation
{
    public class AuthorizeActionValidation
    {
        #region Attributes

        private readonly IUserService _userService;
        private readonly IValidationService _validationService;

        #endregion Attributes

        #region Constructor

        public AuthorizeActionValidation(IUserService userService, IValidationService validationService)
        {
            _userService = userService;
            _validationService = validationService;
        }

        #endregion Constructor

        #region Public Methods

        #region Provider Role

        public async Task ValidateProviderAction(string userEmail, int providerId)
        {
            var user = await _userService.GetUser(userEmail);

            if (providerId == 0)
                return;

            var isAllowed = await _validationService.AutorizedProviderForProvider(user.UserGuid, providerId);

            if (!isAllowed)
            {
                throw new RoleNotAuthorizedException("Not allowed!");
            }
        }

        public async Task ValidateProviderForFacilityAction(string userEmail, int facilityId)
        {
            var user = await _userService.GetUser(userEmail);
            var isAllowed = await _validationService.AutorizedProviderForFacility(user.UserGuid, facilityId);

            if (!isAllowed)
            {
                throw new RoleNotAuthorizedException("Not allowed!");
            }
        }

        #endregion Provider Role

        #region Facility Role

        #endregion Facility Role

        #endregion Public Methods

    }
}
