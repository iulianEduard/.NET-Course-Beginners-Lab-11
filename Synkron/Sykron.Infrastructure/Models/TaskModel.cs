﻿
namespace Sykron.Infrastructure.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int StatusId { get; set; }

        public string StatusName { get; set; }

        public string CreatedOn { get; set; }
    }
}
