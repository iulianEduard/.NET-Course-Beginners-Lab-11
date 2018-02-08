using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Synkwise.Core.Exceptions.Role;
using Synkwise.Repository.Helpers;
using Synkwise.Repository.Models.Account;
using Synkwise.Repository.Ports;
using Synkwise.Core.Exceptions.Account;
using System;
using Dapper;
using Dapper.Core.Base;

namespace Synkwise.Repository
{
    public class AccountRepository : IAccountRepository
    {
        #region Attributes

        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly IRepository<object> _repository;

        #endregion Attributes

        #region Constructor

        public AccountRepository(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, IRepository<object> repository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repository = repository;
        }

        #endregion Constructor

        #region Interface methods

        public async Task<SignInResult> SignIn(UserEntity userEntity, bool rememberMe, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userEntity.Email, password, rememberMe, lockoutOnFailure: false);

            return result;
        }

        public async Task SignOff()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(UserEntity userEntity, string password)
        {
            var result = await _userManager.CreateAsync(userEntity, password);

            return result;
        }

        public async Task<string> GenerateConfirmationToken(UserEntity userEntity)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(userEntity);

            return code;
        }

        public async Task<IdentityResult> ConfirmEmail(UserEntity userEntity, string code)
        {
            var result = await _userManager.ConfirmEmailAsync(userEntity, code);

            return result;
        }

        public async void SignInCreatedUser(UserEntity userEntity)
        {
            await _signInManager.SignInAsync(userEntity, isPersistent: false);
        }

        public async Task<string> GenerateResetPasswordToken(UserEntity userEntity)
        {
            var code = await _userManager.GeneratePasswordResetTokenAsync(userEntity);

            return code;
        }

        public async Task<bool> ForgotPassword(UserEntity userEntity, string email)
        {
            var result = await _userManager.IsEmailConfirmedAsync(userEntity);

            return result;
        }

        public async Task<IdentityResult> ResetPassword(UserEntity userEntity, ResetPasswordEntity resetPasswordEntity)
        {
            var result = await _userManager.ResetPasswordAsync(userEntity, resetPasswordEntity.Code, resetPasswordEntity.Password);

            return result;
        }

        public async Task<UserEntity> GetUser(string email)
        {
            var user = await _userManager.FindByNameAsync(email);

            return user;
        }

        public async Task<UserEntity> GetUserById(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<bool> CheckIfEmailExists(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
                return true;
            else return false;
        }

        public async Task<List<string>> GetUserRoles(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);

            return roles.ToList();
        }

        public async Task AssignRoleToUser(UserEntity userEntity, string role)
        {
            var result = await _userManager.AddToRoleAsync(userEntity, role);

            if(!result.Succeeded)
            {
                throw new RoleInternalServerErrorException(result.Errors.ToExceptionMessage());
            }
        }

        public async Task GetClaims(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var claims = await _userManager.GetClaimsAsync(user);
        }

        public async Task AddClaimsToUser(string email, string claimType, string value)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var claim = new Claim(claimType, value);

            var result = await _userManager.AddClaimAsync(user, claim);

            if(!result.Succeeded)
            {
            }
        }

        public async Task<int> UpdateUser(UserEntity userEntity)
        {
            var result = await _userManager.UpdateAsync(userEntity);

            if(result.Succeeded)
            {
                return userEntity.Id;
            }
            else 
            {
                throw new AccountInternalServerErrorException(result.Errors.ToString());
            }
        }

        public async Task<int?> GetProviderIdByUserId(Guid userId)
        {
            var spParams = new DynamicParameters(new
            {
                @UserId = userId
            });

            var spResult = await _repository.SingleSetStoredProcedureAsync<int?>("dbo.usp_GetProviderByUserId", spParams);

            return spResult.FirstOrDefault();
        }

        #endregion Interface methods

        #region Private Methods

        #endregion Private Methods
    }
}