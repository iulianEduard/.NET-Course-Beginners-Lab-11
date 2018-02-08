using Dapper.Core.Base;
using Synkwise.Repository.Models.Account;
using Synkwise.Repository.Ports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synkwise.Repository
{
    public class RoleRepository : IRoleRepository
    {
        #region Attributes

        private readonly IRepository<RoleEntity> _roleRepository;

        #endregion Attributes

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="roleRepository">Role repository injected by unity</param>
        public RoleRepository(IRepository<RoleEntity> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Get role by id
        /// </summary>
        /// <param name="roleId">Selected role id</param>
        /// <returns>RoleEntity object</returns>
        public async Task<RoleEntity> Get(int roleId)
        {
            //return new RoleEntity() { Id = 2, Name = "Provider" };
            var roleEntity = await _roleRepository.GetAsync(roleId);
            return roleEntity;
        }

        /// <summary>
        /// Get all roles
        /// </summary>
        /// <returns>A collection of RoleEntity</returns>
        public async Task<IEnumerable<RoleEntity>> GetAll()
        {
            var roleCollection = await _roleRepository.GetAllAsync();

            return roleCollection;
        }

        #endregion Public Methods
    }
}
