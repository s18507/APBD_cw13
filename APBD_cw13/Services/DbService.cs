using APBD_cw13.DTOs.Request;
using APBD_cw13.DTOs.Response;
using APBD_cw13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw13.Services
{
    public class DbService : IDbService
    {
        private readonly SweetStoreDbContext _context;

        public DbService(SweetStoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GetOrderResponse> GetCustomerOrder(string nazwisko)
        {
            var responseList = new List<GetOrderResponse>();

			if (!_context.Order.Any())
			{
				return null;
			}

			if (!nazwisko.Equals(""))
			{

				var client = _context.Customers.Where(c => c.LastName.Equals(nazwisko)).FirstOrDefault();

				if (client is null)
				{
					return null; // no customer with such name was found
				}
				var orders = _context.Order.Where(o => o.IdClient.Equals(client.IdClient)).ToList();

				foreach (var order in orders)
				{
					var confectionaryOrderList = _context.confectionary_Orders.Where(co => co.IdOrder.Equals(order.IdOrder)).ToList();

					var confectionaries = new List<string>();

					foreach (var co in confectionaryOrderList)
					{
						confectionaries.Add(_context.Confectionaries.Where(c => c.IdConfectionary.Equals(co.IdConfection)).Select(c => c.Name).FirstOrDefault());
					}

					var response = new GetOrderResponse()
					{
						Nazwisko = nazwisko,
						IdOrder = order.IdOrder,
						DateAccepted = order.DateAccepted,
						DateFinished = order.DateFinished,
						Notes = order.Notes,
						Confectionaries = confectionaries
					};

					responseList.Add(response);
				}

			}
			else
			{

				var clients = _context.Customers.ToList();

				foreach (Customer_confectionary client in clients)
				{
					var orders = _context.Order.Where(o => o.IdClient.Equals(client.IdClient)).ToList();

					foreach (var order in orders)
					{
						var confectionaryOrderList = _context.confectionary_Orders.Where(co => co.IdOrder.Equals(order.IdOrder)).ToList();

						var confectionaries = new List<string>();

						foreach (var co in confectionaryOrderList)
						{
							confectionaries.Add(_context.Confectionaries.Where(c => c.IdConfectionary.Equals(co.IdConfection)).Select(c => c.Name).FirstOrDefault());
						}

						var response = new GetOrderResponse()
						{
							Nazwisko = client.LastName,
							IdOrder = order.IdOrder,
							DateAccepted = order.DateAccepted,
							DateFinished = order.DateFinished,
							Notes = order.Notes,
							Confectionaries = confectionaries
						};

						responseList.Add(response);
					}

				}
			}
			return responseList;
		

	    }
        public string AddOrder(AddOrderRequest request, int customerId)
        {
			using (var trans = _context.Database.BeginTransaction())
			{
				var orderId = _context.Order.Select(o => o.IdOrder).Max() + 1;


				if (request.Confectionery is null || request.Notes is null)
				{
					trans.Rollback();
					return null;
				}
				try
				{

					var Order = new Order
					{
						DateAccepted = request.DateAccepted,
						DateFinished = DateTime.Now,
						Notes = request.Notes,
						IdClient = customerId
					};

					_context.Order.Add(Order);
					_context.SaveChanges();


					// check if confectionary already exists in database if it does add to Confectionary_Order
					foreach (var confec in request.Confectionery)
					{
						var confecId = _context.Confectionaries.Where(c => c.Name.Equals(confec.Name)).Select(c => c.IdConfectionary).FirstOrDefault();
						if (confecId == 0)
						{
							trans.Rollback();
							return null;
						}

						// else add to confictionary_order 
						var confecOrder = new Confectionary_Order
						{
							IdConfection = confecId,
							IdOrder = orderId,
							Quantity = confec.Quantity,
							Notes = confec.Notes
						};

						_context.confectionary_Orders.Add(confecOrder);
						_context.SaveChanges();
					}

					trans.Commit();

					return "Order has been successfully created!";

				}
				catch (Exception e)
				{
					trans.Rollback();
					return null;
				}
			}

			}
     }
}
