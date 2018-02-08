using Microsoft.AspNetCore.Identity;
using Synkwise.Repository.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Synkwise.Repository.Ports
{
    public interface IAccountRepository
    {
        Task<SignInResult> SignIn(UserEntity userEntity, bool rememberMe, string password);

        Task SignOff();

        Task<IdentityResult> Register(UserEntity userEntity, string password);

        Task<string> GenerateConfirmationToken(UserEntity userEntity);

        void SignInCreatedUser(UserEntity userEntity);

        Task<IdentityResult> ConfirmEmail(UserEntity userEntity, string code);

        Task<bool> ForgotPassword(UserEntity userEntity, string email);

        Task<string> GenerateResetPasswordToken(UserEntity userEntity);

        Task<IdentityResult> ResetPassword(UserEntity userEntity, ResetPasswordEntity resetPasswordEntity);

        Task<UserEntity> GetUser(string email);

        Task<UserEntity> GetUserById(string userId);

        Task<bool> CheckIfEmailExists(string email);

        Task AssignRoleToUser(UserEntity userEntity, string role);

        Task<List<string>> GetUserRoles(string email);

        Task<int> UpdateUser(UserEntity userEntity);

        Task<int?> GetProviderIdByUserId(Guid userId);
    }
}
