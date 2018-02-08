using Synkwise.Core.Models.Invitation;
using Synkwise.Repository.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synkwise.BLL.Ports
{
    public interface IInvitationService
    {
        Task<Invitation> Get(int invitationId);

        Task<Invitation> GetbyEmail(string email);

        Task<Invitation> GetByCode(string code);

        Task<Invitation> Save(Invitation invitation);

        Task<Invitation> Update(Invitation invitationEntity);

        Task<InvitationResponse> GetAllByProviderId(int providerId, GridPagination pagination);

        Task<InvitationResponse> GetAll(GridPagination pagination);

        Task ConfirmInvitation(string code, int userId, string confirmationCode);

        Task<int> GetRoleIdByUserId(int userId);
    }
}
