using Synkwise.Repository.Models.Account;
using System;
using System.Threading.Tasks;

namespace Synkwise.Repository.Ports
{
    public interface IIdentityResetPasswordRepository
    {
        Task<IdentityResetPasswordEntity> Get(Guid guid);

        Task<IdentityResetPasswordEntity> Get(int id);

        Task<IdentityResetPasswordEntity> GetByUserId(int userId);

        Task Save(IdentityResetPasswordEntity resetPasswordEntity);
    }
}
