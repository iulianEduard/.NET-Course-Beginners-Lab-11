using Sykron.Infrastructure.Models;
using Synkron.DAL;
using Synkron.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Synkron.BLL.Managers
{
    public class TaskManageManagerBLL
    {
        #region Attributes

        private readonly TaskManageRepository _taskManageRepository = null;

        #endregion Attributes

        #region Constructor

        public TaskManageManagerBLL(TaskManageRepository taskManageRepository)
        {
            _taskManageRepository = taskManageRepository;
        }

        #endregion Constructor

        #region Public Methods

        public TaskManageModel GetById(int id)
        {
            var model = new TaskManageModel();
            var taskManageEntity = _taskManageRepository.GetById(id);

            if(taskManageEntity != null)
            {
                model = ConvertToModel(taskManageEntity);
            }

            return model;
        }

        public List<TaskManageModel> GetTaskManageList()
        {
            var taskManageList = new List<TaskManageModel>();

            var taskManageEntityList = _taskManageRepository.GetAllTaskManage();

            if(taskManageEntityList.Any())
            {
                taskManageEntityList.ForEach(tm => taskManageList.Add(ConvertToModel(tm)));
            }

            return taskManageList;
        }

        public void SaveTaskManage(TaskManageModel model)
        {
            var entity = ConvertToDAL(model);

            if (entity.ID == 0)
            {
                _taskManageRepository.Insert(entity);
            }
            else
            {
                _taskManageRepository.Update(entity);
            }
        }

        public void DeleteTask(int id)
        {
            if(id == 0)
            {
                throw new Exception("Select a task manage to delete");
            }

            var taskManageModel = _taskManageRepository.GetById(id);
            var taskId = taskManageModel.TaskID;

            // Delete task manage
            _taskManageRepository.Delete(taskManageModel);
            
        }

        #endregion Public Methods

        #region Private Methods

        private static TaskManage ConvertToDAL(TaskManageModel model)
        {
            var entity = new TaskManage();

            entity.ID = model.Id;
            entity.FrequencyID = model.FrequencyId;
            entity.TaskID = model.TaskId;
            entity.CreatedOn = DateTime.Now;

            return entity;
        }

        private static TaskManageModel ConvertToModel(usp_GetAllTaskManage_Result entity)
        {
            var model = new TaskManageModel();

            model.Id = entity.ID;
            model.FrequencyName = entity.Frequency;
            model.FrequencyId = entity.FrequencyID;
            model.TaskId = entity.TaskId;
            model.TaskName = entity.TaskName;
            model.Description = entity.Description;

            return model;
        }

        private static TaskManageModel ConvertToModel(TaskManage entity)
        {
            var model = new TaskManageModel();

            model.Id = entity.ID;
            model.TaskId = entity.TaskID ?? 0;
            model.FrequencyId = entity.FrequencyID ?? 0;

            return model;
        }

        #endregion Private Methods

    }
}
