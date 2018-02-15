using Sykron.Infrastructure.Common;
using Sykron.Infrastructure.Models;
using Synkron.DAL;
using Synkron.DAL.Repository;
using System;
using System.Collections.Generic;

namespace Synkron.BLL.Managers
{
    public class TaskManagerBLL
    {
        #region Attributes

        private readonly TaskRepository _taskRepository = null;

        #endregion Attributes

        #region Constructor

        public TaskManagerBLL(TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        #endregion Constructor

        #region Public Methods

        public TaskModel GetTask(int id)
        {
            var taskModel = new TaskModel();

            var taskEntity = _taskRepository.GetById(id);

            taskModel = ConvertToModel(taskEntity);

            return taskModel;
        }

        public List<TaskModel> GetAllTasks()
        {
            var taskList = new List<TaskModel>();

            var taskEntityList = _taskRepository.GetTasksList();

            if(taskEntityList != null)
            {
                taskEntityList.ForEach(tel => taskList.Add(ConvertToModel(tel)));
            }

            return taskList;
        }

        public List<TaskModel> GetUnassignedTasks()
        {
            var unassignedTasks = new List<TaskModel>();

            var unassignedTasksCollection = _taskRepository.GetUnassignedTasks();
            unassignedTasksCollection.ForEach(ut => unassignedTasks.Add(ConvertToModel(ut)));

            return unassignedTasks;
        }

        public List<TaskModel> GetActiveTasks()
        {
            var activeTasks = new List<TaskModel>();

            var activeTasksResponse = _taskRepository.GetTasksByStatus((int)TaskStatusEnum.Active);
            activeTasksResponse.ForEach(at => activeTasks.Add(ConvertToModel(at)));

            return activeTasks;
        }

        public void SaveTask(TaskModel model)
        {
            var taskEntity = new Task();

            taskEntity = ConvertToDAL(model);
            taskEntity.CreatedOn = DateTime.Now;

            _taskRepository.Insert(taskEntity);
        }

        public void ResetStatus(int id, int statusId)
        {
            var taskEntity = _taskRepository.GetById(id);

            if(taskEntity != null)
            {
                taskEntity.StatusID = statusId;

                _taskRepository.Update(taskEntity);
            }
        }

        #endregion Public Methods

        #region Static Methods

        private static Task ConvertToDAL(TaskModel model)
        {
            var taskEntity = new Task();

            taskEntity.ID = model.Id;
            taskEntity.TaskName = model.Name;
            taskEntity.Description = model.Description;
            taskEntity.StatusID = model.StatusId;

            return taskEntity;
        }

        private static TaskModel ConvertToModel(Task entity)
        {
            var taskModel = new TaskModel();

            taskModel.Id = entity.ID;
            taskModel.Name = entity.TaskName;
            taskModel.Description = entity.Description;
            taskModel.StatusId = entity.StatusID ?? 0;

            return taskModel;
        }

        private static TaskModel ConvertToModel(usp_GetAllTasks_Result entity)
        {
            var taskModel = new TaskModel();

            taskModel.Id = entity.Id;
            taskModel.Name = entity.Name;
            taskModel.Description = entity.Description;
            taskModel.StatusId = entity.StatusId;
            taskModel.StatusName = entity.StatusName;

            return taskModel;
        }

        private static TaskModel ConvertToModel(usp_GetUnassignedTasks_Result entity)
        {
            var taskModel = new TaskModel();

            taskModel.Id = entity.ID;
            taskModel.Name = entity.TaskName;

            return taskModel;
        }

        private static TaskModel ConvertToModel(usp_GetTaskByStatus_Result entity)
        {
            var taskModel = new TaskModel();

            taskModel.Id = entity.Id;
            taskModel.Name = entity.TaskName;

            return taskModel;
        }

        #endregion Static Methods
    }
}
