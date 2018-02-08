using System;
using System.Threading.Tasks;
using AutoMapper;
using Synkwise.BLL.Ports;
using Synkwise.Core.Models.Contact;
using Synkwise.Repository.Models.Contact;
using Synkwise.Repository.Ports;

namespace Synkwise.BLL
{
    public class ContactService : IContactService
    {
        #region Attributes

        private readonly IContactRepository _contactRepository;

        private IMapper Mapper { get; set; }

        #endregion

        #region Constructor

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            Mapper = SetMapperConfigs();
        }

        #endregion

        #region Interface Methods

        public async Task<Contact> Get(int id)
        {
            var contactEntity = await _contactRepository.Get(id);

            return Mapper.Map<Contact>(contactEntity);
        }

        public async Task<int> Save(Contact contact)
        {
            var contactEntity = Mapper.Map<ContactEntity>(contact);

            var id = await _contactRepository.Save(contactEntity);

            return id;
        }

        public async Task Delete(Contact contact)
        {
            var contactEntity = Mapper.Map<ContactEntity>(contact);

            await _contactRepository.Delete(contactEntity);
        }

        #endregion

        #region Private methods

        private IMapper SetMapperConfigs()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Contact, ContactEntity>();
                cfg.CreateMap<ContactEntity, Contact>();
            });

            var mapper = config.CreateMapper();

            return mapper;
        }

        #endregion Private methods
    }
}