using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hosting;

namespace AspNet.SignalR.Connections
{
	public class CoffeeConnection : PersistentConnection
	{
		protected override Task OnReceived(IRequest request, string connectionId, string data)
		{
			Connection.Broadcast("message to broadcast");
			return base.OnReceived(request, connectionId, data);
		}

		protected override Task OnConnected(IRequest request, string connectionId)
		{
			return base.OnConnected(request, connectionId);
		}

		public override Task ProcessRequest(HostContext context)
		{
			return base.ProcessRequest(context);
		}

		//protected override bool AuthorizeRequest(IRequest request)
		//{
		//	var name = request.User.Identity.Name;
		//	//var isInRole = request.User.IsInRole("role1");

		//	return base.AuthorizeRequest(request);
		//}
	}
}