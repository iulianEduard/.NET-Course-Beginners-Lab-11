using System.Threading.Tasks;
using AutoMapper;
using Synkwise.API.Managers.Contact;
using Synkwise.API.Models.Profile;
using Synkwise.BLL.Ports;
using Synkwise.Core.Exceptions.Account;
using Synkwise.Core.Exceptions.Profile;
using Synkwise.Core.Models.Account;
using Synkwise.Repository.Helpers;

namespace Synkwise.API.Managers.Profile
{
    public class ProfileManager
    {
        #region Attributes

        private readonly ContactManager _contactManager;
        private readonly IUserService _userService;

        #endregion

        #region Constructor

        public ProfileManager(ContactManager contactManager, IUserService userService)
        {
            _contactManager = contactManager;
            _userService = userService;
        }

        #endregion

        #region Public Methods

        public async Task<ProfileModel> Get(string userId)
        {
            var user = await EnsureUserExists(userId);
            var profileModel = Mapper.Map<ProfileModel>(user);

            await _contactManager.UpdateModelWithContactInformation(profileModel.ContactId, profileModel);

            return profileModel;
        }

        public async Task<string> Update(string userId, ProfileModel profileModel)
        {
            await EnsureUserExists(userId);

            var user = Mapper.Map<User>(profileModel);

            if (profileModel.Contact != null)
            {
                var contactId = await _contactManager.Save(profileModel.Contact);
                user.ContactId = contactId;
            }

            var _userId = await _userService.UpdateUser(user);

            return _userId.ToString();
        }

        #endregion

        #region Private Methods

        private async Task<User> EnsureUserExists(string userId)
        {
            var user = await _userService.GetUserById(userId);

            if (user == null)
            {
                throw new AccountNotFoundException("Cannot find user with Id " + userId);
            }

            return user;
        }

        #endregion
    }
}