using System.ComponentModel.DataAnnotations;

namespace Synkwise.API.Models.Resident.Assessment
{
    public class DetailsActivitiesModel
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

        [StringLength(250, ErrorMessage = "Maximum length is 250 characters!")]
        public string Details { get; set; }
    }
}
