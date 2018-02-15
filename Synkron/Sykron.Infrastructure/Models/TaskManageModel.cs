
namespace Sykron.Infrastructure.Models
{
    public class TaskManageModel
    {
        public int Id { get; set; }

        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public int FrequencyId { get; set; }

        public string FrequencyName { get; set; }

        public string Description { get; set; }
    }
}
