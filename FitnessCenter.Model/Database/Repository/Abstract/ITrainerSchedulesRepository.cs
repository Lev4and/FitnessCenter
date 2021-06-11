using FitnessCenter.Model.Database.Entities;
using System;
using System.Linq;

namespace FitnessCenter.Model.Database.Repository.Abstract
{
    public interface ITrainerSchedulesRepository
    {
        bool ContainsTrainerScheduleByTrainerIdAndDayOfWeekId(Guid trainerId, Guid dayOfWeekId);

        bool SaveTrainerSchedule(TrainerSchedule entity);

        TrainerSchedule GetTrainerScheduleById(Guid id, bool track = false);

        IQueryable<TrainerSchedule> GetTrainerSchedules(bool track = false);

        IQueryable<TrainerSchedule> GetTrainerSchedulesByTrainerId(Guid trainerId, bool track = false);

        void DeleteTrainerScheduleById(Guid id);
    }
}
