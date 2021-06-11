using FitnessCenter.Model.Database.Entities;
using System.Collections.Generic;

namespace FitnessCenter.AspNetCore.Models
{
    public class TrainerScheduleViewModel
    {
        public TrainerSchedule TrainerSchedule { get; set; }

        public List<Trainer> Trainers { get; set; }

        public List<Model.Database.Entities.DayOfWeek> DaysOfWeek { get; set; }
    }
}
