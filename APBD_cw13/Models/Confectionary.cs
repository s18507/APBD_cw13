using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw13.Models
{
    public class Confectionary
    {
		public int IdConfectionary { get; set; }
		public string Name { get; set; }
		public float PricePerIte { get; set; }
		public string Type { get; set; }

		public ICollection<Confectionary_Order> Confectionary_Orders { get; set; }
	}
}
