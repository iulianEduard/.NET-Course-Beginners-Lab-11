using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Synkron.UI.Models.TaskManage
{
    public class TaskManageWorker
    {
        public List<FrequencyUIModel> FrequencyList { get; set; }

        public List<TaskManageUIModel> TaskManageList { get; set; }
    }
}