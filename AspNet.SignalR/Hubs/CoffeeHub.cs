using System;
using System.Threading.Tasks;
using AspNet.SignalR.Helpers;
using Microsoft.AspNet.SignalR;

namespace AspNet.SignalR.Hubs
{
	//[Authorize]
	//[HubName("CoffeeHub")]
	public class CoffeeHub : Hub
	{
		private static readonly OrderChecker _orderChecker =
			new OrderChecker(new Random());

		public void Ping()
		{
			Clients.Caller.Pong();
		}
		public void Send(string name, string message)
		{
			// Call the broadcastMessage method to update clients.
			Clients.All.BroadcastMessage(name, message);
		}

		////[Authorize(Roles = "admin")]
		//public async Task GetUpdateForOrder(Order order)
		//{
		//	//var name = Context.User.Identity.Name;
		//	//var isInRole = Context.User.IsInRole("role1");

		//	await Clients.Others.NewOrder(order);
		//	UpdateInfo result;
		//	do
		//	{
		//		result = _orderChecker.GetUpdate(order);
		//		await Task.Delay(700);
		//		if (!result.New) continue;

		//		await Clients.Caller.ReceiveOrderUpdate(result);
		//		await Clients.Group("allUpdateReceivers").ReceiveOrderUpdate(result);
		//	} while (!result.Finished);
		//	await Clients.Caller.Finished(order);
		//}

		public override Task OnConnected()
		{
			return Clients.All.DisplayMessage(Context.ConnectionId + " OnConnected");
			//if (Context.QueryString["group"] == "allUpdates")
			//	Groups.Add(Context.ConnectionId, "allUpdateReceivers");
			//return base.OnConnected();
		}
	}
}