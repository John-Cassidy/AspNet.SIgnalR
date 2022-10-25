using System;
using System.IO;
using Microsoft.AspNet.SignalR.Client;

namespace Aspnet.SignalR.Client.Samples
{
	public class CommonClient
	{
		private TextWriter _traceWriter;

		public CommonClient(TextWriter traceWriter)
		{
			_traceWriter = traceWriter;
		}

		public void RunSignalRSamples(string url)
		{
			try
			{
				RunHubConnectionAPI(url);
			}
			catch (Exception exception)
			{
				_traceWriter.WriteLine("Exception: {0}", exception);
				throw;
			}
		}

		public void RunWebApiHubsBeds(string url)
		{
			try
			{
				RunWebApiBedsHub(url);
			}
			catch (Exception exception)
			{
				_traceWriter.WriteLine("Exception: {0}", exception);
				throw;
			}
		}

		private void RunWebApiBedsHub(string url)
		{
			var hubConnection = new HubConnection(url)
			{
				TraceWriter = _traceWriter
			};
			hubConnection.Headers.Add("Authorization", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlBoaWxpcHNCRCIsIm5iZiI6MTY2NjE4ODUyNSwiZXhwIjoxNjY2MTk1NzI1LCJpYXQiOjE2NjYxODg1MjUsImlzcyI6IlBoaWxpcHMuaVguV2ViQ29yZSIsImF1ZCI6IlBoaWxpcHMuaVgifQ.p0uCT5LcKFQGtBWdgC9INCt5WncVgJrmiioASMwdZug");

			var hubProxy = hubConnection.CreateHubProxy("BedsHub");
			//hubProxy.On("UpdatePatient", (patient) =>
			//{
			//	hubConnection.TraceWriter.WriteLine("Mobile Patient: {0}", patient);
			//});

			hubConnection.Start().Wait();
			hubConnection.TraceWriter.WriteLine("transport.Name={0}", hubConnection.Transport.Name);

			hubProxy.Invoke("Connect", "C88BA536-6EEE-4C28-851D-EE51648318D8").Wait();

			//hubProxy.Invoke("UpdatePatientServer", "Patient 777").Wait();

			//hubConnection.TraceWriter.WriteLine("Waiting for UpdatePatient to return results.");

			//string joinGroupResponse = hubProxy.Invoke<string>("JoinGroup", hubConnection.ConnectionId, "CommonClientGroup").Result;
			//hubConnection.TraceWriter.WriteLine("joinGroupResponse={0}", joinGroupResponse);

			//hubProxy.Invoke("DisplayMessageGroup", "CommonClientGroup", "Hello Group Members!").Wait();

			//string leaveGroupResponse = hubProxy.Invoke<string>("LeaveGroup", hubConnection.ConnectionId, "CommonClientGroup").Result;
			//hubConnection.TraceWriter.WriteLine("leaveGroupResponse={0}", leaveGroupResponse);

			//hubProxy.Invoke("DisplayMessageGroup", "CommonClientGroup", "Hello Group Members! (caller should not see this message)").Wait();

			//hubProxy.Invoke("DisplayMessageCaller", "Hello Caller again!").Wait();
		}

		private void RunHubConnectionAPI(string url)
		{
			var hubConnection = new HubConnection(url)
			{
				TraceWriter = _traceWriter
			};

			var hubProxy = hubConnection.CreateHubProxy("HubConnectionAPI");
			hubProxy.On<string>("displayMessage", (data) => hubConnection.TraceWriter.WriteLine(data));

			hubConnection.Start().Wait();
			hubConnection.TraceWriter.WriteLine("transport.Name={0}", hubConnection.Transport.Name);

			hubProxy.Invoke("DisplayMessageCaller", "Hello Caller!").Wait();

			string joinGroupResponse = hubProxy.Invoke<string>("JoinGroup", hubConnection.ConnectionId, "CommonClientGroup").Result;
			hubConnection.TraceWriter.WriteLine("joinGroupResponse={0}", joinGroupResponse);

			hubProxy.Invoke("DisplayMessageGroup", "CommonClientGroup", "Hello Group Members!").Wait();

			string leaveGroupResponse = hubProxy.Invoke<string>("LeaveGroup", hubConnection.ConnectionId, "CommonClientGroup").Result;
			hubConnection.TraceWriter.WriteLine("leaveGroupResponse={0}", leaveGroupResponse);

			hubProxy.Invoke("DisplayMessageGroup", "CommonClientGroup", "Hello Group Members! (caller should not see this message)").Wait();

			hubProxy.Invoke("DisplayMessageCaller", "Hello Caller again!").Wait();
		}

	}
}
