using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NasaBanka.Domain.Model;

namespace NasaBanka.Data.Repository
{
    /// <summary>
    /// The "Unit of Work"
    ///     1) decouples the repos from the console,controllers,ASP.NET pages....
    ///     2) decouples the DbContext and EF from the controllers
    ///     3) manages the UoW
    /// </summary>
    /// <remarks>
    /// This class implements the "Unit of Work" pattern in which
    /// the "UoW" serves as a facade for querying and saving to the database.
    /// Querying is delegated to "repositories".
    /// Each repository serves as a container dedicated to a particular
    /// root entity type such as a applicant.
    /// A repository typically exposes "Get" methods for querying and
    /// will offer add, update, and delete methods if those features are supported.
    /// The repositories rely on their parent UoW to provide the interface to the
    /// data .
    /// </remarks>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private BankaDBContext DbContext { get; set; }


        public UnitOfWork()
        {
            CreateDbContext();
        }

        //repositories
        #region Repositries
        private IRepository<Client> _clients;
        private IRepository<Bill> _bills;
        private IRepository<Transaction> _transactions;
         
        
        //get Client repo
        public IRepository<Client> Clients
        {
            get 
            {
                if (_clients == null)
                {
                    _clients = new Repository<Client>(DbContext);
                
                }
                return _clients;
            
            }
        }


        //get Bill repo
        public IRepository<Bill> Bills
        {
            get
            {
                if (_bills == null)
                {
                    _bills = new Repository<Bill>(DbContext);

                }
                return _bills;

            }
        }
        //get Transaction repo
        public IRepository<Transaction> Transactions
        {
            get
            {
                if (_transactions == null)
                {
                    _transactions = new Repository<Transaction>(DbContext);

                }
                return _transactions;

            }
        }

        #endregion
         
        /// <summary>
        /// Save pending changes to the database
        /// </summary>
        public void Commit()
        {
             
            DbContext.SaveChanges();
        }

        protected void CreateDbContext()
        {
            DbContext = new BankaDBContext();

            // Do NOT enable proxied entities, else serialization fails
            //if false it will not get the associated certification and skills when we get the applicants
            DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            DbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            DbContext.Configuration.ValidateOnSaveEnabled = false;

            //DbContext.Configuration.AutoDetectChangesEnabled = false;
            // We won't use this performance tweak because we don't need 
            // the extra performance and, when autodetect is false,
            // we'd have to be careful. We're not being that careful.
        }

         

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion

    }
}
