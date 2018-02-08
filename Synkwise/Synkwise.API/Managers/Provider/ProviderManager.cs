using System.Threading.Tasks;
using AutoMapper;
using Synkwise.API.Managers.Contact;
using Synkwise.API.Models.Provider;
using Synkwise.BLL.Ports;
using Synkwise.Core.Exceptions.Provider;

namespace Synkwise.API.Managers.Provider
{
    public class ProviderManager
    {
        #region Attributes

        private readonly IProviderService _providerService;
        private readonly ContactManager _contactManager;

        #endregion

        #region Constructors

        public ProviderManager(IProviderService providerService, ContactManager contactManager)
        {
            _providerService = providerService;
            _contactManager = contactManager;
        }

        #endregion

        #region Public Methods

        public async Task<ProviderModel> Get(int providerId)
        {
            var provider = await _providerService.Get(providerId);

            if (provider == null)
            {
                throw new ProviderNotFoundException("Cannot find provider in the system!");
            }
            else
            {
                var providerModel = Mapper.Map<ProviderModel>(provider);

                await _contactManager.UpdateModelWithContactInformation(provider.ContactId, providerModel);

                return providerModel;
            }
        }

        public async Task<int> Save(ProviderModel providerModel)
        {
            var contactModel = providerModel.Contact;
            var contactId = await _contactManager.Save(contactModel);

            providerModel.ContactId = contactId;

            return await _providerService.Save(Mapper.Map<Core.Models.Providers.Provider>(providerModel));
        }

        public async Task Delete(int providerId)
        {
            var providerModel = await Get(providerId);

            if (providerModel == null)
            {
                throw new ProviderNotFoundException("Cannot find provider in the system!");
            }
            else
            {
                await _contactManager.Delete(providerModel.Contact);

                var provider = Mapper.Map<Core.Models.Providers.Provider>(providerModel);
                await _providerService.Delete(provider);
            }
        }

        #endregion
    }
}