using System.Web.Http;
using AspNet.SignalR.Models;

namespace AspNet.SignalR.Controllers
{
	[RoutePrefix("api/coffee")]
	public class CoffeeController : ApiController
	{

		private static int OrderId;

		[HttpPost]
		public int OrderCoffee(Order order)
		{
			//var hubContext = GlobalHost.ConnectionManager.GetHubContext<CoffeeHub>();
			//hubContext.Clients.All.NewOrder(order);
			OrderId++;
			return OrderId;
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult GetStatus()
		{
			return Ok();
		}

	}
}
