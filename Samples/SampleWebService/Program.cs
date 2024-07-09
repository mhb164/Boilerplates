using System;
using System.Linq;
using System.Net;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace SampleWebService
{
    internal class Program
    {
        static bool PublishMetadata = true;
        static Uri Address = new Uri($"http://{Environment.MachineName}/TestServices");
        static ServiceHost Host;

        static void Main(string[] args)
        {
            new Thread(() =>
            {
                try
                {
                    Host = new ServiceHost(typeof(TestService), Address);
                    if (PublishMetadata)
                        Host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });// Enable metadata publishing.

                    //Center.HostCreated(this);

                    Host.Closed += OnStateChanged;
                    Host.Closing += OnStateChanged;
                    Host.Faulted += OnStateChanged;
                    Host.Opened += OnStateChanged;
                    Host.Opening += OnStateChanged;

                    OnStateChanged();
                    Host.Open();
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"service> Exception: {exception}");
                }

            })
            { IsBackground = true, Name = "ServiceHost" }.Start();


            Console.WriteLine("Service started, press enter to stop...");
            Console.ReadLine(); 
        }


        private static void OnStateChanged(object sender, EventArgs e)
            => OnStateChanged();

        private static void OnStateChanged()
        {
            Console.WriteLine($"service> State changed to {Host?.State}");
        }

    }

}
