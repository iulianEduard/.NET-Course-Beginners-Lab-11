using Synkwise.Core.Models.Account;
using System;
using System.Threading.Tasks;

namespace Synkwise.BLL.Ports
{
    public interface IIdentityResetPasswordService
    {
        Task<IdentityResetPassword> Get(Guid guid);

        Task<IdentityResetPassword> GetByUserId(int userId);

        Task<IdentityResetPassword> Save(IdentityResetPassword resetPassword);

        Task<IdentityResetPassword> Update(IdentityResetPassword resetPassword);
    }
}
