using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;

namespace FitnessCenter.Model.Database.Repository.Abstract
{
    public interface IServicesRepository
    {
        bool ContainsServiceByCategoryIdAndName(Guid categoryId, string name);

        bool SaveService(Service entity);

        Service GetServiceById(Guid id, bool track = false);

        IQueryable<Service> GetServices(bool track = false);
        
        IQueryable<Service> GetServices(int itemsPerPage, int numberPage, bool track = false);

        void DeleteServiceById(Guid id);
    }
}