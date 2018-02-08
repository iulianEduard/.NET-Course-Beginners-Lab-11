using Synkwise.Repository.Models.Common;
using Synkwise.Repository.Models.Invitation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synkwise.Repository.Ports
{
    public interface IInvitationRepository
    {
        Task<InvitationResult> GetAllByProviderId(int providerId, GridPagination pagination);

        Task<InvitationResult> GetAll(GridPagination pagination);

        Task Save(InvitationEntity invitationEntity);

        Task<InvitationEntity> Get(int invitationId);

        Task<InvitationEntity> GetByEmail(string email);

        Task<InvitationEntity> GetByCode(string code);

        Task ConfirmInvitation(string code, int userId, string confirmationCode);

        Task<int> GetRoleIdByUserId(int userId);
    }
}
