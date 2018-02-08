using Synkwise.Repository.Ports;
using System;
using System.Collections.Generic;
using System.Text;
using Synkwise.Repository.Models.Contact;
using System.Threading.Tasks;
using Dapper.Core.Base;

namespace Synkwise.Repository
{
    public class ContactRepository : IContactRepository
    {
        #region Attributes

        private readonly IRepository<ContactEntity> _contactRepository;

        #endregion Attributes

        #region Constructor

        public ContactRepository(IRepository<ContactEntity> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        #endregion Constructor

        #region Interface Methods

        public async Task<ContactEntity> Get(int id)
        {
            var contactEntity = await _contactRepository.GetAsync(id);

            return contactEntity;
        }

        public async Task<int> Save(ContactEntity contactEntity)
        {
            int id = 0;

            if (contactEntity.Id == 0)
            {
                id = await _contactRepository.AddAsync(contactEntity);
            }
            else
            {
                await _contactRepository.UpdateAsync(contactEntity);
                id = contactEntity.Id;
            }

            return id;
        }

        public async Task Delete(ContactEntity contactEntity)
        {
            await _contactRepository.DeleteAsync(contactEntity);
        }

        #endregion Interface Methods
    }
}