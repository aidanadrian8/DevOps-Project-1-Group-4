﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace devops_project.Models
{
    public class AppUser : IdentityUser
    {
        [ForeignKey("Plant")]
        public int PlantId { get; set; }

        public AppUser(string username, int plantId): base(username)
        {
            PlantId = plantId;
        }
    }
}
