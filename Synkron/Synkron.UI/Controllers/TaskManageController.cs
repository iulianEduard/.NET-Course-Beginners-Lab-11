using Sykron.Infrastructure.Common;
using Sykron.Infrastructure.Models;
using Synkron.BLL.Managers;
using Synkron.UI.Models.TaskManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Synkron.UI.Helpers;

namespace Synkron.UI.Controllers
{
    public class TaskManageController : Controller
    {
        #region Attributes

        private readonly TaskManageManagerBLL _taskManageManager = null;

        private readonly FrequencyManagerBLL _frequencyManager = null;

        private readonly TaskManagerBLL _taskManager = null;

        #endregion Attributes

        #region Constructor

        public TaskManageController(TaskManageManagerBLL taskManageManager, FrequencyManagerBLL frequencyManager, TaskManagerBLL taskManager)
        {
            _taskManageManager = taskManageManager;
            _frequencyManager = frequencyManager;
            _taskManager = taskManager;
        }

        #endregion Constructor

        // GET: TaskManage
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ViewAll()
        {
            var model = new TaskManageWorker();
            model.FrequencyList = new List<FrequencyUIModel>();
            model.TaskManageList = new List<TaskManageUIModel>();

            SetupTaskManageView(model);

            return PartialView("_ViewAll", model);
        }

        // GET: TaskManage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaskManage/Create
        public ActionResult Create()
        {
            var model = new TaskManageUIModel();

            SetupTaskManage(model);

            return View(model);
        }

        // POST: TaskManage/Create
        [HttpPost]
        public ActionResult Create(TaskManageUIModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _taskManageManager.SaveTaskManage(ConverToModel(model));

                    _taskManager.ResetStatus(model.TaskId, (int)TaskStatusEnum.Assigned);

                    return RedirectToAction("Index");
                }
                else
                {
                    SetupTaskManage(model);
                    return View(model);
                }
            }
            catch
            {
                SetupTaskManage(model);
                return View(model);
            }
        }

        // GET: TaskManage/Delete/5
        public JsonResult Delete(int id)
        {
            string result = string.Empty;

            if(id > 0)
            {
                var taskManagerModel = _taskManageManager.GetById(id);

                if(taskManagerModel != null && taskManagerModel.TaskId > 0)
                {
                    var taskModel = _taskManager.GetTask(taskManagerModel.TaskId);

                    _taskManageManager.DeleteTask(id);

                    _taskManager.ResetStatus(taskModel.Id, (int)TaskStatusEnum.Active);

                    var model = new TaskManageWorker();
                    model.FrequencyList = new List<FrequencyUIModel>();
                    model.TaskManageList = new List<TaskManageUIModel>();

                    SetupTaskManageView(model);
                    result = this.RenderPartialView("_ViewAll", model);
                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #region Private Methods

        private void SetupTaskManage(TaskManageUIModel model)
        {
            var taskList = _taskManager.GetUnassignedTasks();

            model.TaskList = new List<SelectListItem>();
            taskList.ForEach(t => model.TaskList.Add(new SelectListItem { Text = t.Name, Value = t.Id.ToString() }));

            var frequencyList = _frequencyManager.GetAllFrequencies();

            model.FrequencyList = new List<SelectListItem>();
            frequencyList.ForEach(f => model.FrequencyList.Add(new SelectListItem { Text = f.Name, Value = f.Id.ToString() }));
        }

        private void SetupTaskManageView(TaskManageWorker model)
        {
            var frequnecyList = new List<FrequencyUIModel>();

            var frequencyData = _frequencyManager.GetAllFrequencies().OrderBy(f => f.Id).ToList();
            frequencyData.ForEach(f => frequnecyList.Add(new FrequencyUIModel { Id = f.Id, Frequency = f.Name }));
            frequnecyList.Insert(0, new FrequencyUIModel { Id = 0, Frequency = "Unassigned Tasks" });

            // Add frequencies
            model.FrequencyList = frequnecyList;

            // Add unassigned tasks
            var unassignedTasks = _taskManager.GetUnassignedTasks();
            unassignedTasks.ForEach(ut => model.TaskManageList.Add(ConvertToUI(ut)));

            // Add assigned tasks
            var assignedTasks = _taskManageManager.GetTaskManageList();
            assignedTasks.ForEach(at => model.TaskManageList.Add(ConvertToUI(at)));
        }

        private TaskManageModel ConverToModel(TaskManageUIModel uiModel)
        {
            var bllModel = new TaskManageModel();

            bllModel.Id = uiModel.Id;
            bllModel.TaskId = uiModel.TaskId;
            bllModel.FrequencyId = uiModel.FrequencyId;

            return bllModel;
        }

        private TaskManageUIModel ConvertToUI(TaskManageModel bllModel)
        {
            var uiModel = new TaskManageUIModel();

            uiModel.Id = bllModel.Id;
            uiModel.TaskId = bllModel.TaskId;
            uiModel.FrequencyId = bllModel.FrequencyId;
            uiModel.TaskName = bllModel.TaskName;
            uiModel.TaskDescription = bllModel.Description;

            return uiModel;
        }

        private TaskManageUIModel ConvertToUI(TaskModel bllModel)
        {
            var uiModel = new TaskManageUIModel();

            uiModel.Id = 0;
            uiModel.TaskId = bllModel.Id;
            uiModel.FrequencyId = 0;
            uiModel.TaskName = bllModel.Name;
            uiModel.TaskDescription = bllModel.Description;

            return uiModel;
        }

        #endregion Private Methods
    }
}
