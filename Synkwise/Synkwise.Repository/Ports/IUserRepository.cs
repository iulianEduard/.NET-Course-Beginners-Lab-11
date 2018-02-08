using Synkwise.Repository.Models.Account;
using System;
using System.Threading.Tasks;

namespace Synkwise.Repository.Ports
{
    public interface IUserRepository
    {
        Task<UserEntity> Get(int userId);

        Task<UserEntity> GetByEmail(string email);

        Task<UserEntity> GetByGuid(Guid userGuid);
    }
}
