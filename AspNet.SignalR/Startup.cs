using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AspNet.SignalR.Startup))]

namespace AspNet.SignalR
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.MapSignalR();
		}
	}
}
