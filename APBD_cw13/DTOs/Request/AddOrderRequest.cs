using APBD_cw13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw13.DTOs.Request
{
    public class AddOrderRequest
    {
        public DateTime DateAccepted{ get; set; }
        public string Notes{ get; set; }
        public ICollection<ConfectionaryRequestModel> Confectionery { get; set; }
    }
}
