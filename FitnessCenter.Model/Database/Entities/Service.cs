using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Model.Database.Entities
{
    public class Service
    {
        public Guid Id { get; set; }
        
        public Guid CategoryId { get; set; }

        public bool RequireATrainer { get; set; }

        public int Price { get; set; }
        
        public int? Duration { get; set; }
        
        public int? CountUses { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        public ServiceCategory Category { get; set; }
        
        public ICollection<ClientService> ClientServices { get; set; }

        public ICollection<TrainerService> TrainerServices { get; set; }
    }
}