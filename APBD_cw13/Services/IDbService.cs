using APBD_cw13.DTOs.Request;
using APBD_cw13.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw13.Services
{
   public interface IDbService
    {
        public IEnumerable<GetOrderResponse> GetCustomerOrder(string nazwisko);
        public string AddOrder(AddOrderRequest request, int customerId);
    }
}
