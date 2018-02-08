using Dapper;
using Dapper.Core.Base;
using Synkwise.Repository.Models.Invitation;
using Synkwise.Repository.Ports;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Synkwise.Repository.Models.Common;
using Synkwise.Core.Helpers;
using Synkwise.Core.Models.Invitation;

namespace Synkwise.Repository
{
    public class InvitationRepository : IInvitationRepository
    {
        #region Attributes

        private readonly IRepository<InvitationEntity> _invitationRepository;

        #endregion Attributes

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="invitationRepository">Injected Invitation dependency</param>
        public InvitationRepository(IRepository<InvitationEntity> invitationRepository)
        {
            _invitationRepository = invitationRepository;
        }

        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Get invitation
        /// </summary>
        /// <param name="invitationId">Selected invitation Id</param>
        /// <returns>Invitation object populated</returns>
        public async Task<InvitationEntity> Get(int invitationId)
        {
            if (invitationId == 0)
                return new InvitationEntity();

            var invitationEntity = await _invitationRepository.GetAsync(invitationId);

            return invitationEntity;
        }

        public async Task<InvitationEntity> GetByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            var invitationEntity = await Task.Run(() => _invitationRepository.GetAll().Where(el => el.EmailTo == email).FirstOrDefault());

            return invitationEntity;
        }

        /// <summary>
        /// Get invitation by code
        /// </summary>
        /// <param name="code">Code that was sent with invitation</param>
        /// <returns>Invitation object</returns>
        public async Task<InvitationEntity> GetByCode(string code)
        {
            var spParams = new DynamicParameters(new
            {
                @Code = code
            });

            var spResult = await _invitationRepository.SingleSetStoredProcedureAsync<InvitationEntity>("dbo.usp_GetInvitationByCode", spParams);
            var entity = spResult.FirstOrDefault();

            return entity;
        }

        public async Task<InvitationResult> GetAll(GridPagination pagination)
        {
            var spParams = new DynamicParameters(pagination.GetGridPaginationInvitation());

            var spResult = await _invitationRepository.MultipleSetStoredProcedureAsync<InvitationResult>("dbo.[usp_GetInvitationsByProviderId]"
                , InvitationResultSet, spParams);

            return spResult;
        }

        /// <summary>
        /// Get all invitations based on provider
        /// </summary>
        /// <param name="providerId">Selected provider Id</param>
        /// <returns>A collection of invitations</returns>
        public async Task<InvitationResult> GetAllByProviderId(int providerId, GridPagination pagination)
        {
            object spParam = pagination.GetGridPagination();
            var spParams = new DynamicParameters(pagination.GetGridPagination());
            spParams.Add("@ProviderID", providerId);

            var spResult = await _invitationRepository.MultipleSetStoredProcedureAsync<InvitationResult>("dbo.[usp_GetInvitationsByProviderId]"
                , InvitationResultSet, spParams);

            //var providerInvitations = await Task.Run(() => _invitationRepository.GetAll().Where(el => el.ProviderId == providerId));

            return spResult;
        }

        /// <summary>
        /// Save the invitation data
        /// </summary>
        /// <param name="invitationEntity">Invitation data</param>
        /// <returns>No result if operation was success</returns>
        public async Task Save(InvitationEntity invitationEntity)
        {
            if (invitationEntity.Id == 0)
            {
                await _invitationRepository.AddAsync(invitationEntity);
            }
            else
            {
                await _invitationRepository.UpdateAsync(invitationEntity);
            }
        }

        /// <summary>
        /// Invitation confirmation by the user
        /// </summary>
        /// <param name="code">Code that was generated and sent in the email</param>
        /// <param name="userId">Generated user id</param>
        /// <returns>No result if operation was success</returns>
        public async Task ConfirmInvitation(string code, int userId, string confirmationCode)
        {
            var spParams = new DynamicParameters(new
            {
                @Code = code,
                @UserId = userId,
                @ConfirmationCode = confirmationCode
            });

            var spResult = await _invitationRepository.SingleSetStoredProcedureAsync<int>("usp_UpdateInvitationByCode", spParams);
        }

        /// <summary>
        /// Get role from user assigned to invitation after registration
        /// </summary>
        /// <param name="userId">Selected user Id</param>
        /// <returns>Role Id</returns>
        public async Task<int> GetRoleIdByUserId(int userId)
        {
            var spParams = new DynamicParameters(new
            {
                @UserId = userId
            });

            var spResponse = await _invitationRepository.SingleSetStoredProcedureAsync<int>("dbo.usp_GetRoleFromInvitationByUserId", spParams);

            return spResponse.FirstOrDefault();
        }

        #endregion Public Methods

        #region Private Methods
        private Func<dynamic, InvitationResult> InvitationResultSet { get; } = gridData =>
        {
            var resultSet = new InvitationResult()
            {
                Data = gridData.Read<InvitationEntity>(),
                TotalCount = gridData.Read<int>()
            };

            return resultSet;
        };

        #endregion Private Methods
    }
}
