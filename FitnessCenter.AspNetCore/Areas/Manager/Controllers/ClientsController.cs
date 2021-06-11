using FitnessCenter.AspNetCore.Models;
using FitnessCenter.Model.Database;
using FitnessCenter.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FitnessCenter.AspNetCore.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class ClientsController : Controller
    {
        private readonly DataManager _dataManager;

        public ClientsController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            var viewModel = new ClientsViewModel()
            {
                Clients = _dataManager.Clients.GetClients().ToList()
            };

            return View(viewModel);
        }

        [Route("~/Manager/Clients/Info/{id}")]
        public IActionResult Info(Guid id)
        {
            return View(_dataManager.Clients.GetClientById(id));
        }

        [Route("~/Manager/Clients/AddService/{clientId}")]
        public IActionResult AddService(Guid clientId)
        {
            var viewModel = new AddServiceViewModel()
            {
                ClientId = clientId,
                ServiceId = default,
                Services = _dataManager.Services.GetServices().ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddService(AddServiceViewModel viewModel)
        {
            if(viewModel.ClientId != default && viewModel.ServiceId != default)
            {
                var service = _dataManager.Services.GetServiceById(viewModel.ServiceId);
                var clientService = new ClientService()
                {
                    PurchasedAt = DateTime.Now,
                    LeftUses = service.CountUses,
                    ClientId = viewModel.ClientId,
                    ServiceId = viewModel.ServiceId,
                    TrainerId = viewModel.TrainerId,
                    ExpiratedAt = service.Duration != null ? (DateTime?)(DateTime.Now.AddMonths((int)service.Duration)) : null,
                };

                if (_dataManager.ClientServices.SaveClientService(clientService))
                {
                    return Redirect($"~/Manager/Clients/Info/{viewModel.ClientId}");
                }
            }

            return View(viewModel);
        }

        [Route("~/Manager/Clients/EditService/{clientServiceId}")]
        public IActionResult EditService(Guid clientServiceId)
        {
            return View(_dataManager.ClientServices.GetClientServiceById(clientServiceId));
        }

        [HttpPost]
        public IActionResult EditService(ClientService viewModel)
        {
            if (viewModel.ClientId != default && viewModel.ServiceId != default)
            {
                if (_dataManager.ClientServices.SaveClientService(viewModel))
                {
                    return Redirect($"~/Manager/Clients/Info/{viewModel.ClientId}");
                }
            }

            return View(viewModel);
        }

        [Route("~/Manager/Clients/DeleteService/{clientId}/{clientServiceId}")]
        public IActionResult DeleteService(Guid clientId, Guid clientServiceId)
        {
            _dataManager.ClientServices.DeleteClientServiceById(clientServiceId);

            return Redirect($"~/Manager/Clients/Info/{clientId}");
        }
    }
}
