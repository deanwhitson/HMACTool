using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace HMACClient
{
    class Program
    {


        static void Main(string[] args)
        {
            RunAsync().Wait();
            Console.ReadLine();
        }

        static async Task RunAsync()
        {
            int i = 1;
            do
            {
                Console.WriteLine("");
                string apiBaseAddress = System.Configuration.ConfigurationManager.AppSettings["apiBaseAddress"];
                Console.WriteLine("Select CAN message to be imported:");
                string CAN00 = Console.ReadLine();
                JObject json = JObject.Parse(File.ReadAllText(CAN00));
                HMACDelegatingHandler customDelegatingHandler = new HMACDelegatingHandler();
                HttpClient client = HttpClientFactory.Create(customDelegatingHandler);
                Console.WriteLine(" - Endpoint: " + apiBaseAddress + "api/ReceiveMessage");
                Console.WriteLine(" - Processing Request ...");
                //CompileError
                HttpResponseMessage response = await client.PostAsJsonAsync(apiBaseAddress + "api/ReceiveMessage", json);

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseString);
                    Console.WriteLine("HTTP Status: {0}, Response Phrase {1}. Press ENTER to exit", (int)response.StatusCode, "Success");
                }
                else
                {
                    Console.WriteLine("Failed to call the API. HTTP Status: {0}, Reason {1}", (int)response.StatusCode, response.ReasonPhrase);
                }
            } while (i == 1);
        }
    }
}
