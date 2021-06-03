using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;
using FitnessCenter.Model.Database.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FitnessCenter.Model.Database.Repository.EntityFramework
{
    public class EFServicesRepository : IServicesRepository
    {
        private readonly FitnessCenterDbContext _context;

        public EFServicesRepository(FitnessCenterDbContext context)
        {
            _context = context;
        }

        public bool ContainsServiceByCategoryIdAndName(Guid categoryId, string name)
        {
            return _context.Services.SingleOrDefault(service => service.CategoryId == categoryId &&
                                                                service.Name == name) != null;
        }

        public bool SaveService(Service entity)
        {
            if (entity.Id == default)
            {
                if (!ContainsServiceByCategoryIdAndName(entity.CategoryId, entity.Name))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetServiceById(entity.Id);

                if (oldVersionEntity.Name != entity.Name)
                {
                    if (!ContainsServiceByCategoryIdAndName(entity.CategoryId, entity.Name))
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

        public Service GetServiceById(Guid id, bool track = false)
        {
            if (track)
            {
                return _context.Services.SingleOrDefault(service => service.Id == id);
            }
            else
            {
                return _context.Services.AsNoTracking().SingleOrDefault(service => service.Id == id);
            }
        }

        public IQueryable<Service> GetServices(bool track = false)
        {
            if (track)
            {
                return _context.Services
                    .Include(service => service.Category);
            }
            else
            {
                return _context.Services
                    .Include(service => service.Category)
                    .AsNoTracking();
            }
        }

        public IQueryable<Service> GetServices(int itemsPerPage, int numberPage, bool track = false)
        {
            if (track)
            {
                return _context.Services
                    .Include(service => service.Category)
                    .OrderBy(service => service.Name)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage);
            }
            else
            {
                return _context.Services
                    .Include(service => service.Category)
                    .OrderBy(service => service.Name)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .AsNoTracking();
            }
        }

        public void DeleteServiceById(Guid id)
        {
            _context.Services.Remove(GetServiceById(id));
            _context.SaveChanges();
        }
    }
}