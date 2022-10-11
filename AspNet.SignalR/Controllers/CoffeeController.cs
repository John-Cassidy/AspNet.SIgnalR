using System.Web.Http;

namespace AspNet.SignalR.Controllers
{
	[RoutePrefix("api/coffee")]
	public class CoffeeController : ApiController
	{
		[HttpGet]
		[Route("")]
		public IHttpActionResult GetStatus()
		{
			return Ok();
		}

	}
}
