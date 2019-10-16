using System;
using System.Net.Http;
using Trippin.Services;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;

namespace Trippin
{
    class Program
    {
        private static HttpClient HttpClient
            = new HttpClient() { BaseAddress = new Uri("https://services.odata.org/TripPinRESTierService/(S(ieqnlsl1mz1m2g1tqktfjtyo))/") };

        static async Task Main(string[] args)
        {
            JsonReader jReader = new JsonReader();
            JsonUser[] users = jReader.ReadUsers("users.json");
            await CheckUsers(users);
        }

        public static async Task <bool> CheckUser (JsonUser user)
        {
            if ((await HttpClient.GetAsync(user.UserName)).IsSuccessStatusCode)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static async Task CheckUsers (JsonUser[] users)
        {
            foreach (JsonUser user in users)
            {
                if (CheckUser(user).Result == false)
                {
                    await PostUser(user);
                }
            }
        }

        public static async Task PostUser (JsonUser user)
        {
            Console.WriteLine((await HttpClient.PostAsync("People", new StringContent(JsonSerializer.Serialize(ConvertJsonUser(user)), Encoding.UTF8))).IsSuccessStatusCode);
        }

        public static TrippinUser ConvertJsonUser(JsonUser user)
        {
            return new TrippinUser
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Emails = new List<string> { user.Email },
                AddressInfo = new List<AddressInfo>
                {
                    new AddressInfo
                    {
                        Address = user.Address, 
                        City = new City
                        {
                            Name = user.CityName, 
                            CountryRegion = user.Country, 
                            Region = user.Country
                        }
                    }
                }
            };
        }
    }
}
