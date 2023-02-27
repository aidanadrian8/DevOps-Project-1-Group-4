using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace devops_project.View_Models
{
    public class PlantViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Location { get; set; }
    }
}