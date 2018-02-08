using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Synkwise.API.FIlters;
using Synkwise.API.Managers.Provider;
using Synkwise.API.Managers.Validation;
using Synkwise.API.Models.Provider;
using Synkwise.Core.Exceptions.Provider;
using System.Threading.Tasks;

namespace Synkwise.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Provider")]
    [Authorize]
    //[ServiceFilter(typeof(ProviderAuthorizationFilter))]
    public class ProviderController : BaseController
    {
        #region Attributes

        private readonly AuthorizeActionValidation _authorizeActionValidation;
        private readonly ProviderManager _providerManager;

        #endregion Attributes

        #region Constructor

        public ProviderController(ProviderManager providerManager, AuthorizeActionValidation authorizeActionValidation)
        {
            _providerManager = providerManager;
            _authorizeActionValidation = authorizeActionValidation;
        }

        #endregion Constructor

        #region Public Methods

        [HttpGet("{providerId}")]
        public async Task<IActionResult> Get(int providerId)
        {
            ValidateProviderId(providerId);

            await _authorizeActionValidation.ValidateProviderAction(GetCurrentUserEmail(), providerId);
            var provider = await _providerManager.Get(providerId);

            return Ok(provider);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] ProviderModel providerModel)
        {
            await _authorizeActionValidation.ValidateProviderAction(GetCurrentUserEmail(), providerModel.Id);

            if (ModelState.IsValid)
            {
                var providerId = await _providerManager.Save(providerModel);

                return Created(Url.RouteUrl(providerModel.Id), providerId);
            }
            else
            {
                throw new ProviderBadRequestException(GetErrorMessage());
            }
        }

        [HttpDelete("{providerId}")]
        public async Task<IActionResult> Delete(int providerId)
        {
            ValidateProviderId(providerId);

            await _authorizeActionValidation.ValidateProviderAction(GetCurrentUserEmail(), providerId);

            await _providerManager.Delete(providerId);
            return NoContent();
        }

        #endregion Public Methods

        #region Private Methods

        private void ValidateProviderId(int providerId)
        {
            if(providerId <= 0)
            {
                throw new ProviderBadRequestException("Invalid provider request!");
            }
        }

        #endregion Private Methods
    }
}