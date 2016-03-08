using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaBanka.Domain.Model
{
    public class Bill
        {
            public Bill()
            {
                this.Transaction = new List<Transaction>();
            }

            public string BillID { get; set; }
            public DateTime DatumOtvaranja { get; set; }
            //[dinarski, devizni]
            public string Tip { get; set; }
            public double Stanje { get; set; }
            public string ClientID { get; set; }    

            public virtual ICollection<Transaction> Transaction { get; set; }
            public virtual Client Client { get; set; }
        }
}