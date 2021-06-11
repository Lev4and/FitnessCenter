using FitnessCenter.Model.Database.Entities;
using FitnessCenter.Model.Database.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FitnessCenter.Model.Database.Repository.EntityFramework
{
    public class EFTrainerServicesRepository : ITrainerServicesRepository
    {
        private readonly FitnessCenterDbContext _context;

        public EFTrainerServicesRepository(FitnessCenterDbContext context)
        {
            _context = context;
        }

        public bool ContainsTrainerServiceByTrainerIdAndServiceId(Guid trainerId, Guid serviceId)
        {
            return _context.TrainerServices.SingleOrDefault(trainerService => trainerService.TrainerId == trainerId 
            && trainerService.ServiceId == serviceId) != null;
        }

        public bool SaveTrainerService(TrainerService entity)
        {
            if(!ContainsTrainerServiceByTrainerIdAndServiceId(entity.TrainerId, entity.ServiceId))
            {
                if(entity.Id == default)
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
                else
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }

        public TrainerService GetTrainerServiceById(Guid id, bool track = false)
        {
            if (track)
            {
                return _context.TrainerServices.SingleOrDefault(trainerService => trainerService.Id == id);
            }
            else
            {
                return _context.TrainerServices.AsNoTracking().SingleOrDefault(trainerService => trainerService.Id == id);
            }
        }

        public IQueryable<TrainerService> GetTrainerServices(bool track = false)
        {
            if (track)
            {
                return _context.TrainerServices
                    .Include(trainerServices => trainerServices.Trainer)
                    .Include(trainerServices => trainerServices.Service);
            }
            else
            {
                return _context.TrainerServices
                    .Include(trainerServices => trainerServices.Trainer)
                    .Include(trainerServices => trainerServices.Service)
                    .AsNoTracking();
            }
        }

        public IQueryable<TrainerService> GetTrainerServicesByTrainerId(Guid trainerId, bool track = false)
        {
            if (track)
            {
                return _context.TrainerServices
                    .Where(trainerService => trainerService.TrainerId == trainerId);
            }
            else
            {
                return _context.TrainerServices
                    .Where(trainerService => trainerService.TrainerId == trainerId)
                    .AsNoTracking();
            }
        }

        public void DeleteTrainerServiceById(Guid id)
        {
            _context.TrainerServices.Remove(GetTrainerServiceById(id));
            _context.SaveChanges();
        }
    }
}
