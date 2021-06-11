using FitnessCenter.Model.Database.Entities;
using System.Collections.Generic;

namespace FitnessCenter.AspNetCore.Models
{
    public class TrainerServiceViewModel
    {
        public TrainerService TrainerService { get; set; }

        public List<Trainer> Trainers { get; set; }

        public List<Service> Services { get; set; }
    }
}
