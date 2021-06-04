using FitnessCenter.Model.Database.Entities;
using System.Collections.Generic;

namespace FitnessCenter.AspNetCore.Models
{
    public class TrainerViewModel
    {
        public Trainer Trainer { get; set; }

        public List<Gender> Genders { get; set; }

        public List<TrainerCategory> TrainerCategories { get; set; }
    }
}
