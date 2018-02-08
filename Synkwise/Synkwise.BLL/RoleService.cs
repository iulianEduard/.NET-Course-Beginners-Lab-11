using AutoMapper;
using Synkwise.BLL.Ports;
using Synkwise.Core.Exceptions.Role;
using Synkwise.Core.Models.Account;
using Synkwise.Repository.Models.Account;
using Synkwise.Repository.Ports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synkwise.BLL
{
    public class RoleService : IRoleService
    {
        #region Attributes

        private readonly IRoleRepository _roleRepository;

        private IMapper Mapper { get; set; }

        #endregion Attributes

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="roleRepository">Role repository injected by unity</param>
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;

            Mapper = SetMapperConfigs();
        }

        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Get role by id
        /// </summary>
        /// <param name="roleId">Selected role id</param>
        /// <returns>Role object</returns>
        public async Task<Role> Get(int roleId)
        {
            var roleEntity = await _roleRepository.Get(roleId);
            var role = Mapper.Map<Role>(roleEntity);

            if(role == null)
            {
                throw new RoleNotFoundException("Request role does not exist!");
            }

            return role;
        }

        /// <summary>
        /// Get all roles
        /// </summary>
        /// <returns>List of Role objects</returns>
        public async Task<List<Role>> GetAll()
        {
            var roleCollection = await _roleRepository.GetAll();
            var roleList = Mapper.Map<List<Role>>(roleCollection);

            return roleList;
        }

        #endregion Public Methods

        #region Private Methods

        private IMapper SetMapperConfigs()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Role, RoleEntity>();
                cfg.CreateMap<RoleEntity, Role>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }

        #endregion Private Methods
    }
}
