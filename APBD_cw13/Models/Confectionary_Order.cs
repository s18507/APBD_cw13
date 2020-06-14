using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw13.Models
{
    public class Confectionary_Order
    {
		public int IdConfection { get; set; }

		//FK + PK
		public int IdOrder { get; set; }


		public int Quantity { get; set; }
		public string Notes { get; set; }

		public Confectionary Confectionary { get; set; }
		public Order Order { get; set; }
	}
}
