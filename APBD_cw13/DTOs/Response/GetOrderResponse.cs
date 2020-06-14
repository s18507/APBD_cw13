using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw13.DTOs.Response
{
    public class GetOrderResponse
    {
		public string Nazwisko { get; set; }
		public int IdOrder { get; set; }
		public DateTime DateAccepted { get; set; }
		public DateTime DateFinished { get; set; }
		public string Notes { get; set; }

		public ICollection<string> Confectionaries { get; set; }
	}
}
