using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(Aspnet.SignalR.Server.Samples.Startup))]

namespace Aspnet.SignalR.Server.Samples
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.UseCors(CorsOptions.AllowAll);
			app.MapSignalR();

			//app.Map("/coffee", map =>
			//{
			//	// Setup the CORS middleware to run before SignalR.
			//	// By default this will allow all origins. You can 
			//	// configure the set of origins and/or http verbs by
			//	// providing a cors options with a different policy.
			//	map.UseCors(CorsOptions.AllowAll);
			//	var hubConfiguration = new HubConfiguration
			//	{
			//		EnableDetailedErrors = true,
			//		//EnableJavaScriptProxies = true,
			//		//EnableJSONP = true
			//	};
			//	// Run the SignalR pipeline. We're not using MapSignalR
			//	// since this branch already runs under the "/signalr"
			//	// path.
			//	map.RunSignalR(hubConfiguration);
			//});
		}
	}
}
