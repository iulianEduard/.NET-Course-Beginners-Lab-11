using AutoMapper;
using Synkwise.BLL.Ports;
using Synkwise.Core.Exceptions.Account;
using Synkwise.Core.Exceptions.Password;
using Synkwise.Core.Exceptions.Register;
using Synkwise.Core.Models.Account;
using Synkwise.Repository.Models.Account;
using Synkwise.Repository.Ports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synkwise.BLL
{
    public class AccountService : IUserService
    { 
        #region Attributes

        private readonly IAccountRepository _accountRepository;

        private IMapper Mapper { get; set; }

        #endregion Attributes

        #region Constructor

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

            Mapper = SetMapperConfigs();
        }

        #endregion Constructor

        #region Interface Methods

        public async Task<string> RegisterUser(RegisterUser user)
        {
            var userEntity = Mapper.Map<UserEntity>(user);
            userEntity.UserName = user.Email;

            var registrationResult = await _accountRepository.Register(userEntity, user.Password);
            if(registrationResult.Succeeded)
            {
                var code = await _accountRepository.GenerateConfirmationToken(userEntity);

                return code;
            }

            throw new RegisterInternalServerErrorException("Cannot generate registration code!");
        }

        public async Task<bool> CheckIfEmailExists(string email)
        {
            return await _accountRepository.CheckIfEmailExists(email);
        }

        public async Task<bool> ConfirmEmail(string userId, string code)
        {
            var user = await _accountRepository.GetUserById(userId);

            if(user == null)
            {
                throw new RegisterInternalServerErrorException("Cannot find user in the system!");
            }

            var confirmationResult = await _accountRepository.ConfirmEmail(user, code);
            if(!confirmationResult.Succeeded)
            {
                throw new RegisterInternalServerErrorException("Cannot confirm registration code!");
            }

            return true;
        }

        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<string> ForgetPassword(User user, string email)
        {
            var userEntity = Mapper.Map<UserEntity>(user);

            var registrationResult = await _accountRepository.ForgotPassword(userEntity, user.Password);
            if (registrationResult)
            {
                var code = await _accountRepository.GenerateResetPasswordToken(userEntity);

                return code;
            }

            throw new AccountInternalServerErrorException("Cannot generate forgot password code!");
        }

        public async Task<User> GetUser(string email)
        {
            var user = await _accountRepository.GetUser(email);

            if (user == null)
            {
                throw new AccountNotFoundException("Cannot find user in the system!");
            }
            var userModel = Mapper.Map<User>(user);

            return userModel;
        }

        public async Task<User> GetUserById(string id)
        {
            var user = await _accountRepository.GetUserById(id);

            if (user == null)
            {
                throw new AccountNotFoundException("Cannot find user in the system!");
            }
            var userModel = Mapper.Map<User>(user);

            return userModel;
        }

        public async Task<bool> ResetPassword(User user, ResetPassword resetPassword)
        {
            var userEntity = Mapper.Map<UserEntity>(user);
            var resetPasswordEntity = Mapper.Map<ResetPasswordEntity>(resetPassword);
            var confirmationResult = await _accountRepository.ResetPassword(userEntity, resetPasswordEntity);

            if (!confirmationResult.Succeeded)
            {
                throw new ResetPasswordException("Cannot reset the password!");
            }

            return true;
        }

        public async Task SignIn(User user)
        {
            var userEntity = Mapper.Map<UserEntity>(user);
            var result = await _accountRepository.SignIn(userEntity, user.RememberMe, user.Password);

            if(!result.Succeeded)
            {
                throw new RegisterInternalServerErrorException("Incorrect user name or password!");
            }

            if(result.IsLockedOut)
            {
                throw new RegisterInternalServerErrorException("User is locked out! Please contact your provider!");
            }

            if(result.IsNotAllowed)
            {
                throw new RegisterInternalServerErrorException("Not allowed!");
            }
        }

        public async Task SignOff()
        {
            await _accountRepository.SignOff();
        }

        public void SignUpUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task AssignRoleToUser(string email, string role)
        {
            var user = await GetUser(email);
            var userEntity = Mapper.Map<UserEntity>(user);

            await _accountRepository.AssignRoleToUser(userEntity, role);
        }

        public async Task<List<string>> GetUserRoles(string email)
        {
            return await _accountRepository.GetUserRoles(email);
        }

        public async Task<int> UpdateUser(User user)
        {
            var userEntity = Mapper.Map<UserEntity>(user);
            
            var userId = await _accountRepository.UpdateUser(userEntity);

            return userId;
        }

        public async Task<int?> GetProviderIdByUserId(Guid userId)
        {
            return await _accountRepository.GetProviderIdByUserId(userId);
        }

        #endregion Interface Methods

        #region Private Methods

        private IMapper SetMapperConfigs()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RegisterUser, UserEntity>();
                cfg.CreateMap<UserEntity, RegisterUser>();

                cfg.CreateMap<User, UserEntity>();
                cfg.CreateMap<UserEntity, User>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }

        #endregion Private Methods
    }
}
