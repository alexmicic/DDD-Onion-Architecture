using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NasaBanka.Domain.Model;

namespace NasaBanka.Data.Repository
{
    public class BankaDBInitializer
        //: CreateDatabaseIfNotExists<BankaDBContext>
        : DropCreateDatabaseAlways<BankaDBContext>
        //: DropCreateDatabaseIfModelChanges<BankaDBContext>
    {
        protected override void Seed(BankaDBContext db)
        {
            // dodaje default podatke u tabele
            // klijenti
            var clients = new List<Client>
            {
                new Client{ClientID = "1" , Ime = "Mirko", Prezime = "Marinkovic", Email = "mirko@test.com",  Telefon = "018555444", Datum = DateTime.Parse("2015-09-01")},
                new Client{ClientID = "2" , Ime = "Marko", Prezime = "Markovic", Email = "marko@test.com", Telefon = "018554444", Datum = DateTime.Parse("2015-09-01")},
                new Client{ClientID = "3" , Ime = "Jelena", Prezime = "Jelic", Email = "jelena@test.com",  Telefon = "018555144", Datum = DateTime.Parse("2015-09-01")},
                new Client{ClientID = "4" , Ime = "Goran", Prezime = "Gojic", Email = "goran@test.com",  Telefon = "0185554424", Datum = DateTime.Parse("2015-09-01")},
                new Client{ClientID = "5" , Ime = "Gojko", Prezime = "Gojkovic", Email = "gojko@test.com",  Telefon = "018555844", Datum = DateTime.Parse("2015-09-01")},
                new Client{ClientID = "6" , Ime = "Milica", Prezime = "Milicic", Email = "milica@test.com",  Telefon = "018557444", Datum = DateTime.Parse("2015-09-01")},
                new Client{ClientID = "7" , Ime = "Jovana", Prezime = "Jovic", Email = "jovana@test.com",  Telefon = "018555494", Datum = DateTime.Parse("2016-01-30")},
                new Client{ClientID = "8" , Ime = "Vladan", Prezime = "Vlajkovic", Email = "vlada@test.com",  Telefon = "018512444", Datum = DateTime.Parse("2016-01-31")},
                new Client{ClientID = "9" , Ime = "Zvonko", Prezime = "Bosic", Email = "zvnoko@test.com",  Telefon = "018554844", Datum = DateTime.Parse("2016-02-21")},
                new Client{ClientID = "10" , Ime = "Dragica", Prezime = "Kesic", Email = "dragica@test.com",  Telefon = "018555114", Datum = DateTime.Parse("2016-02-22")}

            };
            clients.ForEach(s => db.Clients.Add(s));
            db.SaveChanges();

            // racuni
            var bills = new List<Bill>
            {
                new Bill{BillID = "1001" , DatumOtvaranja = DateTime.Parse("2015-09-01"), Stanje = 50000, ClientID = "1", Tip = "dinarski"},
                new Bill{BillID = "1002" , DatumOtvaranja = DateTime.Parse("2015-09-01"), Stanje = 20000, ClientID = "2", Tip = "dinarski"},
                new Bill{BillID = "1003" , DatumOtvaranja = DateTime.Parse("2015-09-01"), Stanje = 15000, ClientID = "3", Tip = "devizni"},
                new Bill{BillID = "1004" , DatumOtvaranja = DateTime.Parse("2015-09-01"), Stanje = 2000, ClientID = "4", Tip = "dinarski"},
                new Bill{BillID = "1005" , DatumOtvaranja = DateTime.Parse("2015-09-01"), Stanje = 10000, ClientID = "5", Tip = "dinarski"},
                new Bill{BillID = "1006" , DatumOtvaranja = DateTime.Parse("2015-09-01"), Stanje = 7000, ClientID = "6", Tip = "dinarski"},
                new Bill{BillID = "1007" , DatumOtvaranja = DateTime.Parse("2015-09-01"), Stanje = 0, ClientID = "7", Tip = "devizni"},
                new Bill{BillID = "1008" , DatumOtvaranja = DateTime.Parse("2015-09-01"), Stanje = 0, ClientID = "8", Tip = "dinarski"},
                new Bill{BillID = "1009" , DatumOtvaranja = DateTime.Parse("2015-09-01"), Stanje = 10000, ClientID = "9", Tip = "dinarski"},
                new Bill{BillID = "1010" , DatumOtvaranja = DateTime.Parse("2015-09-01"), Stanje = 300, ClientID = "10", Tip = "devizni"}
            };

            bills.ForEach(s => db.Bills.Add(s));
            db.SaveChanges();

            // transakcije
            var transactions = new List<Transaction>
            {
                new Transaction{TransactionID = "10001", Datum = DateTime.Parse("2015-02-13"), Tip = "Priliv", Iznos = 2500, BillID = "1001"},
                new Transaction{TransactionID = "10002", Datum = DateTime.Parse("2015-03-03"), Tip = "Odliv", Iznos = 25000, BillID = "1002"},
                new Transaction{TransactionID = "10003", Datum = DateTime.Parse("2015-05-05"), Tip = "Priliv", Iznos = 2000, BillID = "1003"},
                new Transaction{TransactionID = "10004", Datum = DateTime.Parse("2015-08-24"), Tip = "Odliv", Iznos = 1200, BillID = "1004"},
                new Transaction{TransactionID = "10005", Datum = DateTime.Parse("2015-09-10"), Tip = "Priliv", Iznos = 800, BillID = "1005"},
                new Transaction{TransactionID = "10006", Datum = DateTime.Parse("2015-12-07"), Tip = "Odliv", Iznos = 30000, BillID = "1006"},
                new Transaction{TransactionID = "10007", Datum = DateTime.Parse("2015-11-01"), Tip = "Odliv", Iznos = 150, BillID = "1007"},
                new Transaction{TransactionID = "10008", Datum = DateTime.Parse("2015-12-01"), Tip = "Priliv", Iznos = 1500, BillID = "1008"},
                new Transaction{TransactionID = "10009", Datum = DateTime.Parse("2016-01-01"), Tip = "Priliv", Iznos = 15000, BillID = "1009"},
                new Transaction{TransactionID = "10010", Datum = DateTime.Parse("2016-02-01"), Tip = "Odliv", Iznos = 200, BillID = "1010"},
                new Transaction{TransactionID = "10011", Datum = DateTime.Parse("2015-09-01"), Tip = "Priliv", Iznos = 25000, BillID = "1001"},
                new Transaction{TransactionID = "10012", Datum = DateTime.Parse("2015-08-01"), Tip = "Odliv", Iznos = 1500, BillID = "1001"},
                new Transaction{TransactionID = "10013", Datum = DateTime.Parse("2015-07-01"), Tip = "Priliv", Iznos = 1500, BillID = "1001"},
                new Transaction{TransactionID = "10014", Datum = DateTime.Parse("2016-01-11"), Tip = "Priliv", Iznos = 15000, BillID = "1001"},
                new Transaction{TransactionID = "10015", Datum = DateTime.Parse("2016-02-02"), Tip = "Odliv", Iznos = 2500, BillID = "1001"},
                new Transaction{TransactionID = "10016", Datum = DateTime.Parse("2015-01-01"), Tip = "Priliv", Iznos = 2500, BillID = "1001"},
                new Transaction{TransactionID = "10017", Datum = DateTime.Parse("2015-05-21"), Tip = "Odliv", Iznos = 1500, BillID = "1001"},
                new Transaction{TransactionID = "10018", Datum = DateTime.Parse("2015-02-21"), Tip = "Priliv", Iznos = 1500, BillID = "1001"},
                new Transaction{TransactionID = "10019", Datum = DateTime.Parse("2016-01-19"), Tip = "Priliv", Iznos = 15000, BillID = "1002"},
                new Transaction{TransactionID = "10020", Datum = DateTime.Parse("2016-01-20"), Tip = "Odliv", Iznos = 2500, BillID = "1002"},
                new Transaction{TransactionID = "10021", Datum = DateTime.Parse("2015-10-01"), Tip = "Priliv", Iznos = 2500, BillID = "1002"},
                new Transaction{TransactionID = "10022", Datum = DateTime.Parse("2015-11-01"), Tip = "Odliv", Iznos = 1500, BillID = "1002"},
                new Transaction{TransactionID = "10023", Datum = DateTime.Parse("2015-12-01"), Tip = "Priliv", Iznos = 1500, BillID = "1002"},
                new Transaction{TransactionID = "10024", Datum = DateTime.Parse("2016-02-10"), Tip = "Priliv", Iznos = 180000, BillID = "1002"},
                new Transaction{TransactionID = "10025", Datum = DateTime.Parse("2016-02-01"), Tip = "Odliv", Iznos = 2500, BillID = "1003"},
                new Transaction{TransactionID = "10026", Datum = DateTime.Parse("2015-09-01"), Tip = "Priliv", Iznos = 2500, BillID = "1003"},
                new Transaction{TransactionID = "10027", Datum = DateTime.Parse("2015-08-01"), Tip = "Odliv", Iznos = 1500, BillID = "1003"},
                new Transaction{TransactionID = "10028", Datum = DateTime.Parse("2015-07-01"), Tip = "Priliv", Iznos = 1500, BillID = "1003"},
                new Transaction{TransactionID = "10029", Datum = DateTime.Parse("2016-01-11"), Tip = "Priliv", Iznos = 15000, BillID = "1003"},
                new Transaction{TransactionID = "10030", Datum = DateTime.Parse("2016-02-02"), Tip = "Odliv", Iznos = 2500, BillID = "1003"},
                new Transaction{TransactionID = "10031", Datum = DateTime.Parse("2015-01-01"), Tip = "Priliv", Iznos = 2500, BillID = "1003"},
                new Transaction{TransactionID = "10032", Datum = DateTime.Parse("2015-05-21"), Tip = "Odliv", Iznos = 1500, BillID = "1003"},
                new Transaction{TransactionID = "10033", Datum = DateTime.Parse("2015-02-21"), Tip = "Priliv", Iznos = 1500, BillID = "1003"},
                new Transaction{TransactionID = "10034", Datum = DateTime.Parse("2016-02-19"), Tip = "Priliv", Iznos = 150000, BillID = "1003"},
                new Transaction{TransactionID = "10035", Datum = DateTime.Parse("2016-02-20"), Tip = "Odliv", Iznos = 25000, BillID = "1003"}
            };

            transactions.ForEach(s => db.Transactions.Add(s));
            db.SaveChanges();
        }
    }
}
