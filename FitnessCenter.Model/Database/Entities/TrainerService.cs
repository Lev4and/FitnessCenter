using System;

namespace FitnessCenter.Model.Database.Entities
{
    public class TrainerService
    {
        public Guid Id { get; set; }

        public Guid TrainerId { get; set; }

        public Guid ServiceId { get; set; }

        public Trainer Trainer { get; set; }

        public Service Service { get; set; }
    }
}
