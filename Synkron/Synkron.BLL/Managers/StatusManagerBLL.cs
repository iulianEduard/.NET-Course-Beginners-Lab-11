using Sykron.Infrastructure.Models;
using Synkron.DAL;
using Synkron.DAL.Repository;
using System.Collections.Generic;

namespace Synkron.BLL.Managers
{
    public class StatusManagerBLL
    {
        #region Attributes

        private readonly StatusRepository _statusRepository = null;

        #endregion Attributes

        #region Constructor

        public StatusManagerBLL(StatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        #endregion Constructor

        #region Public Methods

        public List<StatusModel> GetStatues()
        {
            var statusList = new List<StatusModel>();

            var statuses = _statusRepository.GetAll();
            statusList = ConvertToModel(statuses);

            return statusList;
        }

        #endregion Public Methods

        #region Private Methods

        private static List<StatusModel> ConvertToModel(List<Status> statusList)
        {
            var statusModelList = new List<StatusModel>();

            statusList.ForEach(s => statusModelList.Add(new StatusModel { Id = s.ID, Name = s.Name }));

            return statusModelList;
        }

        #endregion Private Methods

    }
}
