using FitnessCenter.Model.Database.Entities;
using System;
using System.Linq;

namespace FitnessCenter.Model.Database.Repository.Abstract
{
    public interface ITrainerServicesRepository
    {
        bool ContainsTrainerServiceByTrainerIdAndServiceId(Guid trainerId, Guid serviceId);

        bool SaveTrainerService(TrainerService entity);

        TrainerService GetTrainerServiceById(Guid id, bool track = false);

        IQueryable<TrainerService> GetTrainerServices(bool track = false);

        IQueryable<TrainerService> GetTrainerServicesByTrainerId(Guid trainerId, bool track = false);

        void DeleteTrainerServiceById(Guid id);
    }
}
