using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;
using FitnessCenter.Model.Database.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FitnessCenter.Model.Database.Repository.EntityFramework
{
    public class EFServiceCategoriesRepository : IServiceCategoriesRepository
    {
        private readonly FitnessCenterDbContext _context;

        public EFServiceCategoriesRepository(FitnessCenterDbContext context)
        {
            _context = context;
        }

        public bool ContainsServiceCategoryByName(string name)
        {
            return _context.ServiceCategories.SingleOrDefault(category => category.Name == name) != null;
        }

        public bool SaveServiceCategory(ServiceCategory entity)
        {
            if (!ContainsServiceCategoryByName(entity.Name))
            {
                if (entity.Id == default)
                {
                    _context.Entry(entity).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(entity).State = EntityState.Modified;
                }

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public ServiceCategory GetServiceCategoryById(Guid id, bool track = false)
        {
            if (track)
            {
                return _context.ServiceCategories.SingleOrDefault(category => category.Id == id);
            }
            else
            {
                return _context.ServiceCategories.AsNoTracking().SingleOrDefault(category => category.Id == id);
            }
        }

        public IQueryable<ServiceCategory> GetServiceCategories(bool track = false)
        {
            if (track)
            {
                return _context.ServiceCategories
                    .OrderBy(category => category.Name);
            }
            else
            {
                return _context.ServiceCategories
                    .OrderBy(category => category.Name)
                    .AsNoTracking();
            }
        }

        public void DeleteServiceCategoryById(Guid id)
        {
            _context.ServiceCategories.Remove(GetServiceCategoryById(id));
            _context.SaveChanges();
        }
    }
}