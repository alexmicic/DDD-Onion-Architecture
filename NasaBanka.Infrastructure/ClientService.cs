using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NasaBanka.Data.Repository;
using NasaBanka.Domain.Model;

namespace NasaBanka.Infrastructure
{
    public class ClientService:IClientService
    {
        private readonly IUnitOfWork uow;
        private string _actionMonth;
        private string _actionTransaction;
        private string _actionMonthEuro;

        public ClientService()
        {
            this.uow = new UnitOfWork();
            this._actionMonth = "month";
            this._actionTransaction = "din";
            this._actionMonthEuro = "eur";
        }

        public IQueryable<Client> GetAll()
        {
            var clients = uow.Clients.GetAll();
            return clients;
        }

        public List<Client> GetAll(string action)
        {
            if (action == _actionMonth)
            {
                List<Client> list = new List<Client>();
                var clients = uow.Clients.GetAll();
                DateTime today = DateTime.Now;
                foreach(var client in clients){
                    var date = client.Datum;
                    TimeSpan diff = today - date;
                    if (diff.TotalDays < 30)
                    {
                        list.Add(client);
                    }
                }
                return list;
            }
            if (action == _actionTransaction)
            {
                List<Client> list = new List<Client>();
                var clients = uow.Clients.GetAll();
                var bills = uow.Bills.GetAll();
                var transactions = uow.Transactions.GetAll();
                DateTime today = DateTime.Now;

                var billIdFirst = transactions.First().BillID;
                double total = 0;
                foreach (var transaction in transactions)
                {
                    var billType = bills.Where(i => i.BillID == transaction.BillID).First().Tip;

                    if (billType == "dinarski")
                    {

                        var date = transaction.Datum;
                        TimeSpan diff = today - date;
                        goto Begin;

                    Begin:
                        // ako je isti ID racuna
                        if (transaction.BillID != billIdFirst)
                        {
                            if (transaction.Tip == "Priliv")
                            {
                                if (diff.TotalDays < 30)
                                {
                                    total += transaction.Iznos;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        // ako nije isti ID racuna
                        else
                        {
                            goto Dodaj;
                        }

                    Dodaj:

                        if (total >= 100000)
                        {
                            // nadji klijenta 
                            var bill = bills.Where(i => i.BillID == transaction.BillID).First();
                            var clientID = bill.ClientID;
                            list.Add(clients.Where(i => i.ClientID == clientID).First());
                        }

                        // postavi novi ID
                        billIdFirst = transaction.BillID;

                        // resetuj total
                        total = 0;

                        continue;
                    }
                    else
                    {
                        continue;
                    } 
                }
                return list;
            }
            if (action == _actionMonthEuro)
            {
                List<Client> list = new List<Client>();
                var clients = uow.Clients.GetAll();
                var bills = uow.Bills.GetAll();
                var transactions = uow.Transactions.GetAll();
                DateTime today = DateTime.Now;

                var billIdFirst = transactions.First().BillID;
                double total = 0;
                foreach (var transaction in transactions)
                {
                    var billType = bills.Where(i => i.BillID == transaction.BillID).First().Tip;

                    if (billType == "devizni")
                    {

                        var date = transaction.Datum;
                        TimeSpan diff = today - date;
                        goto Begin;

                    Begin:
                        // ako je isti ID racuna
                        if (transaction.BillID != billIdFirst)
                        {
                            if (transaction.Tip == "Priliv")
                            {
                                if (diff.TotalDays < 30)
                                {
                                    total += transaction.Iznos;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        // ako nije isti ID racuna
                        else
                        {
                            goto Dodaj;
                        }

                    Dodaj:

                        if (total >= 1000)
                        {
                            // nadji klijenta 
                            var bill = bills.Where(i => i.BillID == transaction.BillID).First();
                            var clientID = bill.ClientID;
                            list.Add(clients.Where(i => i.ClientID == clientID).First());
                        }

                        // postavi novi ID
                        billIdFirst = transaction.BillID;

                        // resetuj total
                        total = 0;

                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
                return list;
            }
            return null;
        }
    }
}
