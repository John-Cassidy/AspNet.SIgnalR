using System;
using System.Diagnostics;
using System.Linq;

namespace Aspnet.SignalR.Client.Samples
{
	internal class Program
	{
		private static void Main(string[] args)
		{
#if DEBUG
			if (args.Any(a => a == "--debug"))
			{
				args = args.Where(a => a != "--debug").ToArray();
				Console.WriteLine($"Ready for debugger to attach. Process ID: {Process.GetCurrentProcess().Id}.");
				Console.WriteLine("Press ENTER to continue.");
				Console.ReadLine();
			}
#endif

			var writer = Console.Out;
			var client = new CommonClient(writer);
			//client.RunSignalRCoffee("http://localhost:53923/");

			client.RunSignalRSamples("http://localhost:63935/");

			//// DEBUG
			////client.RunWebApiHubsBeds("http://localhost:52785/api/hubs/beds/");
			//// IIS ON PORT 5051
			////client.RunWebApiHubsBeds("http://localhost:5051/api/hubs/beds/");

			Console.ReadKey();
		}
	}
}
