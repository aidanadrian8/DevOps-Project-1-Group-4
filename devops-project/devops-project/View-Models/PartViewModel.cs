using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace devops_project.View_Models 
{
    public class PartViewModel
    {
        [Required]
        [Display(Name = "SKU")]
        [StringLength(8, MinimumLength = 8)]
        public string SKU { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(50, MinimumLength = 4)]
        public string Name {get; set;}

        [Required]
        [StringLength(255)]
        public string Specs { get; set; }

        [Required]
        [RegularExpression("^(\\$)?(([1-9]\\d{0,2}(\\,\\d{3})*)|([1-9]\\d*)|(0))(\\.\\d{2})?$")]
        public decimal? SalePrice { get; set; }

        [Required]
        [RegularExpression("^(\\$)?(([1-9]\\d{0,2}(\\,\\d{3})*)|([1-9]\\d*)|(0))(\\.\\d{2})?$")]
        public decimal? ManufacturingPrice { get; set; }


    }
}