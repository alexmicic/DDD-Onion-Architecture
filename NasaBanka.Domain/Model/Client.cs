using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NasaBanka.Domain.Model
{
    public class Client
    {
        public Client()
        {
            this.Bill = new List<Bill>();
        }

        public string ClientID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public DateTime Datum { get; set; }

        public virtual ICollection<Bill> Bill { get; set; }
    }
}
