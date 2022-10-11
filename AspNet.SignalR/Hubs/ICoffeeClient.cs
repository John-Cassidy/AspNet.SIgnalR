﻿using System.Threading.Tasks;
using AspNet.SignalR.Models;

namespace AspNet.SignalR.Hubs
{
	public interface ICoffeeClient
	{
		Task NewOrder(Order order);
		Task ReceiveOrderUpdate(UpdateInfo info);
		Task Finished(Order order);
	}
}
