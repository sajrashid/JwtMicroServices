using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ConsoleClient
{
    class Program
    {
        public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        private static async Task MainAsync()
        {

            // get token
            var client = new HttpClient();
            var K = new Key();
            K.APIKey="q1WkAk+jB3K1jc2cbwNDDO5JjwleCmUWhw/aPCay9J8=";
            var url = "http://localhost.fiddler:5000/api/token";
            string json = JsonConvert.SerializeObject(K);
            var stringcontent = new StringContent(json, Encoding.UTF8, "application/json");

            var token = string.Empty;

            var response = await client.PostAsync(url, stringcontent);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                var obj = JsonConvert.DeserializeObject<RootObject>(content);
                token= obj.token;
                // we are using regex to remove bearer with ignore case!!!
                string cleanToken = Regex.Replace(token, "bearer ", "", RegexOptions.IgnoreCase);

                token = cleanToken;
            }

            if (token!=string.Empty)
            {// call api
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                response = await client.GetAsync("http://localhost.fiddler:5001/api/values");
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.StatusCode);
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(JArray.Parse(content));
                }

            }

            
        }
    }


    public class Key
    {
        public String APIKey { get; set; }

    }

    public class RootObject
    {
        public string token { get; set; }
    }
}
