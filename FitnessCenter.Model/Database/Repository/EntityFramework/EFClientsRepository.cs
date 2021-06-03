using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;
using FitnessCenter.Model.Database.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FitnessCenter.Model.Database.Repository.EntityFramework
{
    public class EFClientsRepository : IClientsRepository
    {
        private readonly FitnessCenterDbContext _context;

        public EFClientsRepository(FitnessCenterDbContext context)
        {
            _context = context;
        }

        public bool ContainsClientByUserId(Guid userId)
        {
            return _context.Clients.SingleOrDefault(client => client.UserId == userId) != null;
        }

        public bool SaveClient(Client entity)
        {
            if (entity.Id == default)
            {
                if (!ContainsClientByUserId(entity.UserId))
                {
                    _context.Entry(entity).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var oldVersionEntity = GetClientById(entity.Id);

                if (oldVersionEntity.UserId != entity.UserId)
                {
                    if (!ContainsClientByUserId(entity.UserId))
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

        public Client GetClientById(Guid id, bool track = false)
        {
            if (track)
            {
                return _context.Clients.SingleOrDefault(client => client.Id == id);
            }
            else
            {
                return _context.Clients.AsNoTracking().SingleOrDefault(client => client.Id == id);
            }
        }

        public Client GetClientByUserId(Guid userId, bool track = false)
        {
            if (track)
            {
                return _context.Clients.SingleOrDefault(client => client.UserId == userId);
            }
            else
            {
                return _context.Clients.AsNoTracking().SingleOrDefault(client => client.UserId == userId);
            }
        }

        public IQueryable<Client> GetClients(bool track = false)
        {
            if (track)
            {
                return _context.Clients.Include(client => client.Gender);
            }
            else
            {
                return _context.Clients
                    .Include(client => client.Gender)
                    .AsNoTracking();
            }
        }

        public IQueryable<Client> GetClients(int itemsPerPage, int numberPage, bool track = false)
        {
            if (track)
            {
                return _context.Clients
                    .Include(client => client.Gender)
                    .OrderBy(client => client.Id)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage);
            }
            else
            {
                return _context.Clients
                    .Include(client => client.Gender)
                    .OrderBy(client => client.Id)
                    .Skip((numberPage - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .AsNoTracking();
            }
        }

        public void DeleteClientById(Guid id)
        {
            _context.Clients.Remove(GetClientById(id));
            _context.SaveChanges();
        }
    }
}