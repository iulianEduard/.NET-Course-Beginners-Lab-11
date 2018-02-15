using Sykron.Infrastructure.Models;
using Synkron.BLL.Managers;
using Synkron.UI.Models.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Synkron.UI.Controllers
{
    public class TaskController : Controller
    {
        #region Attributes

        private readonly TaskManagerBLL _taskManager = null;

        private readonly StatusManagerBLL _statusManager = null;

        #endregion Attributes

        #region Constructor

        public TaskController(TaskManagerBLL taskManager, StatusManagerBLL statusManger)
        {
            _taskManager = taskManager;
            _statusManager = statusManger;
        }

        #endregion Constructor

        #region Public Methods

        // GET: Task
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ViewAll()
        {
            var taskList = new List<TaskViewModel>();

            taskList = ConvertToModel(_taskManager.GetAllTasks());

            return PartialView("_ViewAll", taskList);
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            var model = new TaskUIModel();

            var statusList = _statusManager.GetStatues();
            model.StatusList = ConvertToSelectList(statusList);

            return View(model);
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(TaskUIModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    _taskManager.SaveTask(ConvertToBLL(model));
                    return RedirectToAction("Index");
                }
                else
                {
                    SetupTask(model);
                    return View(model);
                }
            }
            catch
            {
                SetupTask(model);
                return View();
            }
        }

        #endregion Public Actions

        #region Private Methods

        private static List<TaskViewModel> ConvertToModel(List<TaskModel> bllList)
        {
            var taskList = new List<TaskViewModel>();

            foreach(var bllItem in bllList)
            {
                var taskItem = new TaskViewModel();

                taskItem.Id = bllItem.Id;
                taskItem.Name = bllItem.Name;
                taskItem.Description = bllItem.Description;
                taskItem.Status = bllItem.StatusName;

                taskList.Add(taskItem);
            }

            return taskList;
        }

        private static List<SelectListItem> ConvertToSelectList(List<StatusModel> statusListModel)
        {
            var selectList = new List<SelectListItem>();

            statusListModel.ForEach(sl => selectList.Add(new SelectListItem { Text = sl.Name, Value = sl.Id.ToString() }));

            return selectList;
        }

        private static TaskModel ConvertToBLL(TaskUIModel uiModel)
        {
            var bllModel = new TaskModel();

            bllModel.Id = 0;
            bllModel.Name = uiModel.Name;
            bllModel.Description = uiModel.Description;
            bllModel.StatusId = uiModel.StatusId;

            return bllModel;
        }

        private void SetupTask(TaskUIModel model)
        {
            var statusList = _statusManager.GetStatues();
            model.StatusList = ConvertToSelectList(statusList);
        }

        #endregion Private Methods
    }
}
