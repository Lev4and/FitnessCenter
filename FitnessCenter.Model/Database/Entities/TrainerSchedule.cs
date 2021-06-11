using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Model.Database.Entities
{
    public class TrainerSchedule
    {
        public Guid Id { get; set; }

        public Guid TrainerId { get; set; }

        public Guid DayOfWeekId { get; set; }

        [Range(0, 23)]
        public int From { get; set; }

        [Range(0, 23)]
        public int Until { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public Trainer Trainer { get; set; }
    }
}
