using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;
using FitnessCenter.Model.Database.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FitnessCenter.Model.Database.Repository.EntityFramework
{
    public class EFClientServicesRepository : IClientServicesRepository
    {
        private readonly FitnessCenterDbContext _context;

        public EFClientServicesRepository(FitnessCenterDbContext context)
        {
            _context = context;
        }

        public bool SaveClientService(ClientService entity)
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

        public ClientService GetClientServiceById(Guid id, bool track = false)
        {
            if (track)
            {
                return _context.ClientServices
                    .Include(clientService => clientService.Client).ThenInclude(client => client.Gender)
                    .Include(clientService => clientService.Service).ThenInclude(service => service.Category)
                    .SingleOrDefault(service => service.Id == id);
            }
            else
            {
                return _context.ClientServices
                    .Include(clientService => clientService.Client).ThenInclude(client => client.Gender)
                    .Include(clientService => clientService.Service).ThenInclude(service => service.Category)
                    .AsNoTracking().SingleOrDefault(service => service.Id == id);
            }
        }

        public IQueryable<ClientService> GetClientServices(bool track = false)
        {
            if (track)
            {
                return _context.ClientServices
                    .Include(service => service.Service)
                    .Include(service => service.Client)
                    .ThenInclude(client => client.Gender)
                    .OrderByDescending(service => service.PurchasedAt);
            }
            else
            {
                return _context.ClientServices                    
                    .Include(service => service.Service)
                    .Include(service => service.Client)
                    .ThenInclude(client => client.Gender)
                    .OrderByDescending(service => service.PurchasedAt)
                    .AsNoTracking();
            }
        }

        public IQueryable<ClientService> GetClientService(int itemsPerPage, int numberPerPage, bool track = false)
        {
            if (track)
            {
                return _context.ClientServices
                    .Include(service => service.Service)
                    .Include(service => service.Client)
                    .ThenInclude(client => client.Gender)
                    .OrderByDescending(service => service.PurchasedAt)
                    .Skip((numberPerPage - 1) * itemsPerPage)
                    .Take(itemsPerPage);
            }
            else
            {
                return _context.ClientServices                    
                    .Include(service => service.Service)
                    .Include(service => service.Client)
                    .ThenInclude(client => client.Gender)
                    .OrderByDescending(service => service.PurchasedAt)
                    .Skip((numberPerPage - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .AsNoTracking();
            }
        }

        public IQueryable<ClientService> GetClientServicesByClientId(Guid clientId, bool track = false)
        {
            if (track)
            {
                return _context.ClientServices
                    .Include(service => service.Service)
                    .Include(service => service.Client)
                    .ThenInclude(client => client.Gender)
                    .Where(service => service.ClientId == clientId)
                    .OrderByDescending(service => service.PurchasedAt);
            }
            else
            {
                return _context.ClientServices                    
                    .Include(service => service.Service)
                    .Include(service => service.Client)
                    .ThenInclude(client => client.Gender)
                    .Where(service => service.ClientId == clientId)
                    .OrderByDescending(service => service.PurchasedAt)
                    .AsNoTracking();
            }
        }

        public IQueryable<ClientService> GetClientServicesByClientId(Guid clientId, int itemsPerPage, int numberPerPage, bool track = false)
        {
            if (track)
            {
                return _context.ClientServices
                    .Include(service => service.Service)
                    .Include(service => service.Client)
                    .ThenInclude(client => client.Gender)
                    .Where(service => service.ClientId == clientId)
                    .OrderByDescending(service => service.PurchasedAt)
                    .Skip((numberPerPage - 1) * itemsPerPage)
                    .Take(itemsPerPage);
            }
            else
            {
                return _context.ClientServices                    
                    .Include(service => service.Service)
                    .Include(service => service.Client)
                    .ThenInclude(client => client.Gender)
                    .Where(service => service.ClientId == clientId)
                    .OrderByDescending(service => service.PurchasedAt)
                    .Skip((numberPerPage - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .AsNoTracking();
            }
        }

        public void DeleteClientServiceById(Guid id)
        {
            _context.ClientServices.Remove(GetClientServiceById(id));
            _context.SaveChanges();
        }
    }
}