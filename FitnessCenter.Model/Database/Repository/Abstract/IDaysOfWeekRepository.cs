using System;
using System.Linq;

namespace FitnessCenter.Model.Database.Repository.Abstract
{
    public interface IDaysOfWeekRepository
    {
        Entities.DayOfWeek GetDayOfWeekById(Guid id, bool track = false);

        IQueryable<Entities.DayOfWeek> GetDaysOfWeek(bool track = false);
    }
}
