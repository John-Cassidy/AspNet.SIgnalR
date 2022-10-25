using System.Threading.Tasks;
using AspNet.SignalR.Models;

namespace AspNet.SignalR.Hubs
{
	public interface ICoffeeClient
	{
		Task DisplayMessage(string message);
		Task NewOrder(Order order);
		Task ReceiveOrderUpdate(UpdateInfo info);
		Task Finished(Order order);
		Task BroadcastMessage(string name, string message);
		Task Pong();
	}
}
