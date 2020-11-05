using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PrClient
{
    class Program
    {
        private const string MediaType = "application/json";
        private static readonly HttpClient _client = new HttpClient();
        private const string BASE_URL = "https://localhost:44345";

        static async Task Main(string[] args)
        {
            while (await CheckInput()()){}
        }

        private static Func<Task<bool>> CheckInput()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Escape : return Exit;
                case ConsoleKey.N : return AddNewClient;
                case ConsoleKey.L: return GetUsers;
                default: return () =>
                {
                    Console.Clear();
                    Console.WriteLine("Press key...");
                    return Task.FromResult(true);
                };
            }
        }

        private static Task SendJson<T>(T model)
            => _client.PostAsync(
                $"{BASE_URL}/Patients/New", new StringContent(
                    JsonSerializer.Serialize(model), 
                    Encoding.UTF8,
                    MediaType));


        private static Task<HttpResponseMessage> GetAllPatientsJson()
            => _client.GetAsync($"{BASE_URL}/Patients/All");

        private static async Task<bool> GetUsers()
        {
            Console.Clear();
            var result = await GetAllPatientsJson();
            Console.WriteLine(await result.Content.ReadAsStringAsync());
            return true;
        }

        private static Task<bool> Exit()
        {
            Console.Clear();
            Console.WriteLine("Press any key to extit...");
            Console.ReadKey();
            return Task.FromResult(false);
        }

        private static async Task<bool> AddNewClient()
        {
            var user = new User();
            Console.Clear();
            Console.Write("First name: ");
            user.FirstName = Console.ReadLine();
            Console.Write("Last name: ");
            user.LastName = Console.ReadLine();
            Console.Write("Age: ");
            user.Age = int.Parse(Console.ReadLine());
            Console.Write("Email address: ");
            user.EmailAddress = Console.ReadLine();
            Console.Write("Covid date: ");
            user.TestCovid = DateTime.TryParse(Console.ReadLine(), out var date) 
                ? date as DateTime? 
                : null ;

            await SendJson(user);

            Console.WriteLine("Success!");

            return true;
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? TestCovid { get; set; }
    }
}
