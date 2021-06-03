using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;

namespace FitnessCenter.Model.Database.Repository.Abstract
{
    public interface IClientsRepository
    {
        bool ContainsClientByUserId(Guid userId);

        bool SaveClient(Client entity);

        Client GetClientById(Guid id, bool track = false);

        Client GetClientByUserId(Guid userId, bool track = false);

        IQueryable<Client> GetClients(bool track = false);

        IQueryable<Client> GetClients(int itemsPerPage, int numberPage, bool track = false);

        void DeleteClientById(Guid id);
    }
}