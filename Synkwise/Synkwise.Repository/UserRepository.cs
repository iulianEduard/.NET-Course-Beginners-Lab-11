using Dapper;
using Dapper.Core.Base;
using Microsoft.AspNetCore.Identity;
using Synkwise.Repository.Models.Account;
using Synkwise.Repository.Ports;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Synkwise.Repository
{
    public class UserRepository : IUserRepository
    {
        #region Attributes

        private readonly IRepository<UserEntity> _userRepository;
        private readonly UserManager<UserEntity> _userManager;

        #endregion Attributes

        #region Constructor

        public UserRepository(IRepository<UserEntity> userRepository, UserManager<UserEntity> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        #endregion Constructor

        #region Public Methods

        public async Task<UserEntity> Get(int userId)
        {
            var userEntity = await _userManager.FindByIdAsync(userId.ToString());

            return userEntity;
        }

        public async Task<UserEntity> GetByEmail(string email)
        {
            var userEntity = await _userManager.FindByEmailAsync(email);

            return userEntity;
        }

        public Task<UserEntity> GetByGuid(Guid userGuid)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}
