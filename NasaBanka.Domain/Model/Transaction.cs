using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaBanka.Domain.Model
{
    public class Transaction
    {
        public string TransactionID { get; set; }
        public DateTime Datum { get; set; }
        //[priliv, odliv]
        public string Tip { get; set; }
        public double Iznos { get; set; }
        public string BillID { get; set; }

        public virtual Bill Bill { get; set; }
    }
}
