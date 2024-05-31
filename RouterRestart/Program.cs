using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string routerUrl = "http://192.168.1.1/rebootinfo.cgi"; // Replace with your router's URL
        string username = "admin"; // Replace with your router's username
        string password = "9b1be13a"; // Replace with your router's password

        // Encode the credentials to Base64 for basic authentication
        string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);

            try
            {
                HttpResponseMessage response = await client.PostAsync(routerUrl, null);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Router restart request sent successfully.");
                }
                else
                {
                    Console.WriteLine($"Failed to send restart request. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}