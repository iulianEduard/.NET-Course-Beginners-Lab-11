using AutoMapper;
using Synkwise.Core.Exceptions.Account;
using Synkwise.Core.Models.Account;
using Synkwise.Repository.Models.Account;
using Synkwise.Repository.Ports;
using System;
using System.Threading.Tasks;

namespace Synkwise.BLL.Ports
{
    public class IdentityResetPasswordService : IIdentityResetPasswordService
    {
        #region Attributes

        private readonly IIdentityResetPasswordRepository _resetPasswordRepository;

        private IMapper Mapper { get; set; }

        #endregion Attributes

        #region Constructor

        public IdentityResetPasswordService(IIdentityResetPasswordRepository resetPasswordRepository)
        {
            _resetPasswordRepository = resetPasswordRepository;

            Mapper = SetMapperConfigs();
        }

        #endregion Constructor


        #region Public Methods

        public async Task<IdentityResetPassword> GetByUserId(int userId)
        {
            var resetPasswordEntity = await _resetPasswordRepository.GetByUserId(userId);
            var resetPassword = Mapper.Map<IdentityResetPassword>(resetPasswordEntity);

            return resetPassword;
        }

        public async Task<IdentityResetPassword> Get(Guid guid)
        {
            var resetPasswordEntity = await _resetPasswordRepository.Get(guid);
            var resetPassword = Mapper.Map<IdentityResetPassword>(resetPasswordEntity);

            return resetPassword;
        }

        /// <summary>
        /// Save resetPassword entity
        /// </summary>
        /// <param name="resetPassword">resetPassword object</param>
        /// <returns>No result in case of success</returns>
        public async Task<IdentityResetPassword> Save(IdentityResetPassword resetPassword)
        {
            var resetPasswordEntity = Mapper.Map<IdentityResetPasswordEntity>(resetPassword);

            if (resetPasswordEntity == null)
            {
                throw new AccountInternalServerErrorException("Cannot save reset password data!");
            }

            PreSaveWorker(resetPasswordEntity);

            await _resetPasswordRepository.Save(resetPasswordEntity);

            return Mapper.Map<IdentityResetPassword>(resetPasswordEntity);
        }

        /// <summary>
        /// Update reset password properties after confirm or new reset password
        /// </summary>
        /// <param name="invitation"></param>
        /// <returns></returns>
        public async Task<IdentityResetPassword> Update(IdentityResetPassword resetPassword)
        {
            var resetPasswordEntity = await _resetPasswordRepository.Get(resetPassword.ID);

            if (resetPasswordEntity == null && resetPasswordEntity.ID > 0)
            {
                throw new AccountInternalServerErrorException("Cannot update reset password data!");
            }

            resetPasswordEntity = Mapper.Map<IdentityResetPasswordEntity>(resetPassword);
            if (resetPassword.UsedDate == null)
                PreSaveWorker(resetPasswordEntity);

            await _resetPasswordRepository.Save(resetPasswordEntity);

            return Mapper.Map<IdentityResetPassword>(resetPasswordEntity);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Set mapping objects
        /// </summary>
        /// <returns>IMapper object filled with mappings configurations</returns>
        private IMapper SetMapperConfigs()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<IdentityResetPassword, IdentityResetPasswordEntity>();
                cfg.CreateMap<IdentityResetPasswordEntity, IdentityResetPassword>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }

        private void PreSaveWorker(IdentityResetPasswordEntity resetPasswordEntity)
        {
            resetPasswordEntity.CreatedDate = DateTime.Now;
            resetPasswordEntity.Guid = Guid.NewGuid();
        }

        #endregion Private Methods
    }
}
