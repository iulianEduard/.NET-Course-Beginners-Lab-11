using Sykron.Infrastructure.Models;
using Synkron.DAL;
using Synkron.DAL.Repository;
using System.Collections.Generic;

namespace Synkron.BLL.Managers
{
    public class FrequencyManagerBLL
    {
        #region Attributes

        private readonly FrequencyRepository _frequencyRepository = null;

        #endregion Attributes

        #region Constructor

        public FrequencyManagerBLL(FrequencyRepository frequencyRepository)
        {
            _frequencyRepository = frequencyRepository;
        }

        #endregion Constructor

        #region Public Methods

        public List<FrequencyModel> GetAllFrequencies()
        {
            var frequencyList = new List<FrequencyModel>();

            frequencyList = ConvertToModel(_frequencyRepository.GetAll());

            return frequencyList;
        }

        #endregion Public Methods

        #region Private Methods

        private static List<FrequencyModel> ConvertToModel(List<Frequency> frequencyCollection)
        {
            var frequencyList = new List<FrequencyModel>();

            frequencyCollection.ForEach(f => frequencyList.Add(new FrequencyModel { Id = f.ID, Name = f.Frequency1 }));

            return frequencyList;
        }

        #endregion Private Methods
    }
}
