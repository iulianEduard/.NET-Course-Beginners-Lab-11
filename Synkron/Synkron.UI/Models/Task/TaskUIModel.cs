using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Synkron.UI.Models.Task
{
    public class TaskUIModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a name")]
        [StringLength(50, ErrorMessage = "Length cannot exceed 50 characters")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a description")]
        [StringLength(250, ErrorMessage = "Length cannot exceed 250 characters")]
        public string Description { get; set; }

        [Display(Name = "Status")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a status")]
        public int StatusId { get; set; }

        public List<SelectListItem> StatusList { get; set; }
    }
}