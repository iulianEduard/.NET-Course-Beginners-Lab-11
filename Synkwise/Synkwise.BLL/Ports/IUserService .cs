using Synkwise.Core.Models.Account;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System;

namespace Synkwise.BLL.Ports
{
    public interface IUserService
    {
        void SignUpUser(User user);

        void CreateUser(User user);

        Task<string> RegisterUser(RegisterUser user);

        Task SignIn(User user);

        Task SignOff();

        Task<bool> ConfirmEmail(string userId, string code);

        Task<string> ForgetPassword(User user, string email);

        Task<bool> ResetPassword(User user, ResetPassword resetPassword);

        Task<User> GetUser(string email);

        Task<User> GetUserById(string id);

        Task<bool> CheckIfEmailExists(string email);

        Task AssignRoleToUser(string email, string role);

        Task<List<string>> GetUserRoles(string email);

        Task<int> UpdateUser(User user);

        Task<int?> GetProviderIdByUserId(Guid userId);
    }
}
