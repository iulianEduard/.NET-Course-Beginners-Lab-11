using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Synkwise.API.Managers.Profile;
using Synkwise.API.Models.Profile;
using Microsoft.AspNetCore.Cors;

namespace Synkwise.API.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Produces("application/json")]
    [Route("api")]
    public class ProfileController : BaseController
    {
        #region Attributes

        private readonly ProfileManager _profileManager;

        #endregion Attributes

        #region Constructor

        public ProfileController(ProfileManager profileManager)
        {
            _profileManager = profileManager;
        }

        #endregion Constructor

        #region Public Methods

        [HttpGet("users/{userId}/profile")]
        public async Task<IActionResult> Get(string userId)
        {
            var profileModel = await _profileManager.Get(userId);
            return Ok(profileModel);
        }

        [HttpPost("users/{userId}/profile")]
        public async Task<IActionResult> Update(string userId, [FromBody] ProfileModel profileModel)
        {
            var updatedUserId = await _profileManager.Update(userId, profileModel);
            return Ok(updatedUserId);
        }

        #endregion
    }
}