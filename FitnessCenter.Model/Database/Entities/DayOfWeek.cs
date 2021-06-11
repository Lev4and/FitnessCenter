using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Model.Database.Entities
{
    public class DayOfWeek
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<TrainerSchedule> TrainerSchedules { get; set; }
    }
}
