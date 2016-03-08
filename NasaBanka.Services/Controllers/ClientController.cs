using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NasaBanka.Infrastructure;
using NasaBanka.Domain.Model;
using NasaBanka.Data.Repository;

namespace NasaBanka.Controllers
{
    public class ClientController : ApiController
    {
        private readonly IClientService clientService;

        public ClientController()
        {
            this.clientService = new ClientService();
        }

        public IQueryable<Client> GetClient()
        {
            return clientService.GetAll();
        }

        public List<Client> GetClient(string action)
        {
            return clientService.GetAll(action);
        }
    }
}
