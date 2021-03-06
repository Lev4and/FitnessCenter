using System;

namespace FitnessCenter.Model.Database.Entities
{
    public class ClientService
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }
        
        public Guid ServiceId { get; set; }

        public Guid? TrainerId { get; set; }
        
        public int? LeftUses { get; set; }

        public DateTime? ExpiratedAt { get; set; }
        
        public DateTime PurchasedAt { get; set; }
        
        public Client Client { get; set; }

        public Trainer Trainer { get; set; }

        public Service Service { get; set; }

        public bool IsActive()
        {
            if(LeftUses == 0 || ExpiratedAt < DateTime.Now)
            {
                return false;
            }

            return true;
        }
    }
}