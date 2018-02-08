using System.Threading.Tasks;
using AutoMapper;
using Synkwise.API.Models.Contact;
using Synkwise.BLL.Ports;
using Synkwise.Core.Exceptions.Contact;

namespace Synkwise.API.Managers.Contact
{
    public class ContactManager
    {
        #region Attributes

        private readonly IContactService _contactService;

        #endregion

        #region Constructor

        public ContactManager(IContactService contactService)
        {
            _contactService = contactService;
        }

        #endregion

        #region Public Methods

        public async Task UpdateModelWithContactInformation(int contactId, ContactableModel contactOwner)
        {
            var contact = await _contactService.Get(contactId);

            if (contact == null)
            {
                throw new ContactNotFoundException("Cannot find contact in the system!");
            }
            else
            {
                var contactModel = Mapper.Map<ContactModel>(contact);

                contactOwner.Contact = contactModel;
            }
        }

        public async Task<int> Save(ContactModel contactModel)
        {
                var contact = Mapper.Map<Core.Models.Contact.Contact>(contactModel);

                var contactId = await _contactService.Save(contact);

                return contactId;
        }

        public async Task Delete(ContactModel contactModel)
        {
            var contact = Mapper.Map<Core.Models.Contact.Contact>(contactModel);
            await _contactService.Delete(contact);
        }

        #endregion
    }
}