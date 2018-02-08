using System;
using System.Collections.Generic;
using System.Text;

namespace Synkwise.Core.Models.Task
{
    public class TaskDetailsDomain
    {
        public int Id { get; set; }

        public int TaskId { get; set; }

        public Guid CompletedByUserId { get; set; }

        public DateTime CompletedOn { get; set; }

        public DateTime ScheduledDate { get; set; }
    }
}
