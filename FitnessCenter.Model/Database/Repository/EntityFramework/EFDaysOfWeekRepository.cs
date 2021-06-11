using FitnessCenter.Model.Database.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.Model.Database.Repository.EntityFramework
{
    public class EFDaysOfWeekRepository : IDaysOfWeekRepository
    {
        private readonly FitnessCenterDbContext _context;

        public EFDaysOfWeekRepository(FitnessCenterDbContext context)
        {
            _context = context;
        }

        public Entities.DayOfWeek GetDayOfWeekById(Guid id, bool track = false)
        {
            if (track)
            {
                return _context.DaysOfWeek.SingleOrDefault(dayOfWeek => dayOfWeek.Id == id);
            }
            else
            {
                return _context.DaysOfWeek.AsNoTracking().SingleOrDefault(dayOfWeek => dayOfWeek.Id == id);
            }
        }

        public IQueryable<Entities.DayOfWeek> GetDaysOfWeek(bool track = false)
        {
            if (track)
            {
                return _context.DaysOfWeek;
            }
            else
            {
                return _context.DaysOfWeek.AsNoTracking();
            }
        }
    }
}
