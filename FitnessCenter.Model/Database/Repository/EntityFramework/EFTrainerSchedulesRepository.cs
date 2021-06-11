using FitnessCenter.Model.Database.Entities;
using FitnessCenter.Model.Database.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FitnessCenter.Model.Database.Repository.EntityFramework
{
    public class EFTrainerSchedulesRepository : ITrainerSchedulesRepository
    {
        private readonly FitnessCenterDbContext _context;

        public EFTrainerSchedulesRepository(FitnessCenterDbContext context)
        {
            _context = context;
        }

        public bool ContainsTrainerScheduleByTrainerIdAndDayOfWeekId(Guid trainerId, Guid dayOfWeekId)
        {
            return _context.TrainerSchedules.SingleOrDefault(trainerSchedule => trainerSchedule.TrainerId == trainerId && 
            trainerSchedule.DayOfWeekId == dayOfWeekId) != null;
        }

        public bool SaveTrainerSchedule(TrainerSchedule entity)
        {
            if(entity.Id == default)
            {
                if(!ContainsTrainerScheduleByTrainerIdAndDayOfWeekId(entity.TrainerId, entity.DayOfWeekId))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetTrainerScheduleById(entity.Id);

                if(oldVersionEntity.TrainerId != entity.TrainerId || oldVersionEntity.DayOfWeekId != entity.DayOfWeekId)
                {
                    if (!ContainsTrainerScheduleByTrainerIdAndDayOfWeekId(entity.TrainerId, entity.DayOfWeekId))
                    {
                        _context.Entry(entity).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
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

        public TrainerSchedule GetTrainerScheduleById(Guid id, bool track = false)
        {
            if (track)
            {
                return _context.TrainerSchedules.SingleOrDefault(trainerSchedule => trainerSchedule.Id == id);
            }
            else
            {
                return _context.TrainerSchedules.AsNoTracking().SingleOrDefault(trainerSchedule => trainerSchedule.Id == id);
            }
        }

        public IQueryable<TrainerSchedule> GetTrainerSchedules(bool track = false)
        {
            if (track)
            {
                return _context.TrainerSchedules
                    .Include(trainerSchedule => trainerSchedule.Trainer)
                    .Include(trainerSchedule => trainerSchedule.DayOfWeek);
            }
            else
            {
                return _context.TrainerSchedules
                    .Include(trainerSchedule => trainerSchedule.Trainer)
                    .Include(trainerSchedule => trainerSchedule.DayOfWeek)
                    .AsNoTracking();
            }
        }

        public IQueryable<TrainerSchedule> GetTrainerSchedulesByTrainerId(Guid trainerId, bool track = false)
        {
            if (track)
            {
                return _context.TrainerSchedules
                    .Where(trainerSchedule => trainerSchedule.TrainerId == trainerId);
            }
            else
            {
                return _context.TrainerSchedules
                    .AsNoTracking()
                    .Where(trainerSchedule => trainerSchedule.TrainerId == trainerId);
            }
        }

        public void DeleteTrainerScheduleById(Guid id)
        {
            _context.TrainerSchedules.Remove(GetTrainerScheduleById(id));
            _context.SaveChanges();
        }
    }
}
