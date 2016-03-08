using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NasaBanka.Domain.Model;
using NasaBanka.Data.Repository;

namespace NasaBanka.Infrastructure
{
    public interface IClientService
    {
        IQueryable<Client> GetAll();
        List<Client> GetAll(string action);
    }
}
