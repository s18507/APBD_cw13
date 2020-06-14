using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw13.Models
{
    public class Order
    {
        public int IdOrder { get; set; }
        public DateTime DateAccepted { get; set; }
        public DateTime DateFinished { get; set; }
        public string Notes { get; set; }
        public int IdClient { get; set; }
        public Nullable<int> IdEmployee { get; set; }

        public Customer_confectionary Customer { get; set; }
        public Employee_confectionary Employee { get; set; }
        public ICollection<Confectionary_Order> Confectionary_Orders { get; set; }
    }
}
