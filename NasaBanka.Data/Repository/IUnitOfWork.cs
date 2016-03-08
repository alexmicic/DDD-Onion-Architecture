using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NasaBanka.Domain.Model;

namespace NasaBanka.Data.Repository
{
    /// <summary>
    /// Interface for the Unit of Work"
    /// </summary>
    public interface IUnitOfWork
    {
        // Save pending changes to the data store.
        void Commit();

        // Repositories
        IRepository<Client> Clients { get; }
        IRepository<Bill> Bills { get; }
        IRepository<Transaction> Transactions { get; }
    }
}
