using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace devops_project.Models
{
    public class AppUser : IdentityUser
    {
        [ForeignKey("Plant")]
        public int PlantId { get; set; }
        [NotMapped]
        public Plant Plant { get; set; }
    }
}
