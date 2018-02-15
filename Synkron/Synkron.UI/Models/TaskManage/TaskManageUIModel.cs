using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Synkron.UI.Models.TaskManage
{
    public class TaskManageUIModel
    {
        public int Id { get; set; }

        [Display(Name = "Task")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a task")]
        public int TaskId { get; set; }

        public List<SelectListItem> TaskList { get; set; }

        [Display(Name = "Frequency")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a frequency")]
        public int FrequencyId { get; set; }

        public List<SelectListItem> FrequencyList { get; set; }

        public string TaskName { get; set; }

        public string TaskDescription { get; set; }
    }
}