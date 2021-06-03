using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Model.Database.Entities
{
    public class ServiceCategory
    {
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public ICollection<Service> Services { get; set; }
    }
}