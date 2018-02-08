using System;
using System.Collections.Generic;
using System.Text;

namespace Synkwise.Core.Models.Task
{
    public class TaskDomain
    {
        public int Id { get; set; }

        public int TypeId { get; set; }

        public string TaskType { get; set; }

        public string CreatetBy { get; set; }

        public Guid UserId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int StatusId { get; set; }

        public string Status { get; set; }
    }
}
