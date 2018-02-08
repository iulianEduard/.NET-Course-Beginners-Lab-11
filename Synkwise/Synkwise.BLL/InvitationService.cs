using AutoMapper;
using Synkwise.BLL.Ports;
using Synkwise.Core.Exceptions.Invitation;
using Synkwise.Core.Exceptions.Role;
using Synkwise.Core.Models.Invitation;
using Synkwise.Repository.Models.Common;
using Synkwise.Repository.Models.Invitation;
using Synkwise.Repository.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Synkwise.BLL
{
    public class InvitationService : IInvitationService
    {
        #region Attributes

        private readonly IInvitationRepository _invitationRepository;

        private IMapper Mapper { get; set; }

        #endregion Attributes

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="invitationRepository">Invitation repository dependency</param>
        public InvitationService(IInvitationRepository invitationRepository)
        {
            _invitationRepository = invitationRepository;

            Mapper = SetMapperConfigs();
        }

        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Get invitation
        /// </summary>
        /// <param name="invitationId">Selected invitation or 0 for a new one</param>
        /// <returns>Invitation object</returns>
        public async Task<Invitation> Get(int invitationId)
        {
            var invitationEntity = await _invitationRepository.Get(invitationId);
            var invitation = Mapper.Map<Invitation>(invitationEntity);

            if (invitation == null)
            {
                throw new InvitationInternalServerErrorException("Cannot load selected invitation!");
            }

            return invitation;
        }

        public async Task<Invitation> GetbyEmail(string email)
        {
            var invitationEntity = await _invitationRepository.GetByEmail(email);
            var invitation = Mapper.Map<Invitation>(invitationEntity);

            //if (invitation == null)
            //{
            //throw new InvitationInternalServerErrorException("Cannot get selected invitation!");
            //}

            return invitation;
        }

        /// <summary>
        /// Get invitation based on code
        /// </summary>
        /// <param name="code">Code that was sent in the invitation email</param>
        /// <returns>Invitation object</returns>
        public async Task<Invitation> GetByCode(string code)
        {
            var invitationEntity = await _invitationRepository.GetByCode(code);
            var invitation = Mapper.Map<Invitation>(invitationEntity);

            if(invitation == null)
            {
                throw new InvitationInternalServerErrorException("Cannot find invitation based on provided code!");
            }

            return invitation;
        }

        public async Task<InvitationResponse> GetAll(GridPagination pagination)
        {
            var result = await _invitationRepository.GetAll(pagination);
            var invitationsResponse = new InvitationResponse()
            {
                Data = Mapper.Map<List<InvitationListDetail>>(result.Data),
                TotalCount = result.TotalCount.ToList().FirstOrDefault()
            };

            return invitationsResponse;
        }


        public async Task<InvitationResponse> GetAllByProviderId(int providerId, GridPagination pagination)
        {
            if (providerId <= 0)
                throw new InvitationNotFoundException("Not found");

            var invitationResult = await _invitationRepository.GetAllByProviderId(providerId, pagination);
            return Mapper.Map<InvitationResponse>(invitationResult);
        }

        /// <summary>
        /// Save invitation entity
        /// </summary>
        /// <param name="invitation">Invitation object</param>
        /// <returns>No result in case of success</returns>
        public async Task<Invitation> Save(Invitation invitation)
        {
            var invitationEntity = Mapper.Map<InvitationEntity>(invitation);

            if (invitationEntity == null)
            {
                throw new InvitationInternalServerErrorException("Cannot save invitation!");
            }

            PreSaveWorker(invitationEntity);

            await _invitationRepository.Save(invitationEntity);

            return Mapper.Map<Invitation>(invitationEntity);
        }

        public async Task<Invitation> Update(Invitation invitation)
        {
            var invitationEntity = await _invitationRepository.Get(invitation.Id);
           
            if (invitationEntity == null && invitationEntity.Id > 0)
            {
                throw new InvitationInternalServerErrorException("Cannot update invitation!");
            }

            invitationEntity = Mapper.Map<InvitationEntity>(invitation);
            invitationEntity.LastModifiedDate = DateTime.Now;

            await _invitationRepository.Save(invitationEntity);

            return Mapper.Map<Invitation>(invitationEntity);
        }

        /// <summary>
        /// Invitation confirmation by the user
        /// </summary>
        /// <param name="code">Code that was generated and sent in the email</param>
        /// <param name="userId">User id generated</param>
        /// <returns>No result if operation was success</returns>
        public async Task ConfirmInvitation(string code, int userId, string confirmationCode)
        {
            await _invitationRepository.ConfirmInvitation(code, userId, confirmationCode);
        }

        /// <summary>
        /// Get role from user assigned to invitation
        /// </summary>
        /// <param name="userId">Selected user id</param>
        /// <returns>Role id</returns>
        public async Task<int> GetRoleIdByUserId(int userId)
        {
            int roleId = await _invitationRepository.GetRoleIdByUserId(userId);

            if(roleId == 0)
            {
                throw new RoleNotFoundException("Requested role was not found!");
            }

            return roleId;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Set mapping objects
        /// </summary>
        /// <returns>IMapper object filled with mappings configurations</returns>
        private IMapper SetMapperConfigs()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Invitation, InvitationEntity>();
                cfg.CreateMap<InvitationEntity, Invitation>();

                cfg.CreateMap<InvitationEntity, InvitationListDetail>();
                
                cfg.CreateMap<InvitationResult, InvitationResponse>();
                cfg.CreateMap<InvitationResponse, InvitationResult>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }

        private void PreSaveWorker(InvitationEntity invitationEntity)
        {
            invitationEntity.GeneratedDate = DateTime.Now;
            invitationEntity.Code = Guid.NewGuid().ToString();
        }

        #endregion Private Methods
    }
}
