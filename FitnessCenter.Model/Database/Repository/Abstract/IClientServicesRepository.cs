using System;
using System.Linq;
using FitnessCenter.Model.Database.Entities;

namespace FitnessCenter.Model.Database.Repository.Abstract
{
    public interface IClientServicesRepository
    {
        bool SaveClientService(ClientService entity);

        ClientService GetClientServiceById(Guid id, bool track = false);

        IQueryable<ClientService> GetClientServices(bool track = false);

        IQueryable<ClientService> GetClientService(int itemsPerPage, int numberPerPage, bool track = false);
        
        IQueryable<ClientService> GetClientServicesByClientId(Guid clientId, bool track = false);
        
        IQueryable<ClientService> GetClientServicesByClientId(Guid clientId, int itemsPerPage, int numberPerPage, 
            bool track = false);

        void DeleteClientServiceById(Guid id);
    }
}