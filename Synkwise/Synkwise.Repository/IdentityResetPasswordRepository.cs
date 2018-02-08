using Dapper.Core.Base;
using Synkwise.Repository.Models.Account;
using Synkwise.Repository.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synkwise.Repository
{
    public class IdentityResetPasswordRepository : IIdentityResetPasswordRepository
    {
        #region Attributes

        private readonly IRepository<IdentityResetPasswordEntity> _resetPasswordRepository;

        #endregion Attributes

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="resetPasswordRepository">resetPasswordRepository repository injected by unity</param>
        public IdentityResetPasswordRepository(IRepository<IdentityResetPasswordEntity> resetPasswordRepository)
        {
            _resetPasswordRepository = resetPasswordRepository;
        }

        #endregion Constructor

        #region Public Methods

        public async Task<IdentityResetPasswordEntity> Get(int id)
        {
            var resetPasswordEntity = await _resetPasswordRepository.GetAsync(id);

            return resetPasswordEntity;
        }

        public async Task<IdentityResetPasswordEntity> GetByUserId(int userId)
        {
            var resetPasswordEntity = await Task.Run(() => _resetPasswordRepository.GetAll().Where(el => el.UserID == userId).FirstOrDefault());

            return resetPasswordEntity;
        }

        /// <summary>
        /// Get reset password by guid
        ///
        /// <param name="guid">Selected guid</param>
        /// <returns>IdentityResetPasswordEntity object</returns>
        public async Task<IdentityResetPasswordEntity> Get(Guid guid)
        {
            if (guid == null)
                return null;

            var resetPasswordEntity = await Task.Run(() => _resetPasswordRepository.GetAll().Where(el => el.Guid == guid).FirstOrDefault());

            return resetPasswordEntity;
        }

        /// <summary>
        /// Save the reset password data
        /// </summary>
        /// <param name="IdentityResetPasswordEntity">reset Pasword data</param>
        /// <returns>No result if operation was success</returns>
        public async Task Save(IdentityResetPasswordEntity resetPasswordEntity)
        {
            if (resetPasswordEntity.ID == 0)
            {
                await _resetPasswordRepository.AddAsync(resetPasswordEntity);
            }
            else
            {
                await _resetPasswordRepository.UpdateAsync(resetPasswordEntity);
            }
        }

        #endregion Public Methods
    }
}
