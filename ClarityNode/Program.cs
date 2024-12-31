
using ClarityNode.Logic;
using ClarityNode.Models;
using System.Net.Http.Json;

namespace ClarityNode
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var httpClientHandler = new HttpClientHandler();
            // Return `true` to allow certificates that are untrusted/invalid
            httpClientHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            HttpClient client = new HttpClient(httpClientHandler);
            var result = await client.GetAsync($@"https://data-api.ecb.europa.eu/service/data/EXR/D.USD.EUR.SP00.A?startPeriod=2024-10-01&format=csvdata&endPeriod=2024-12-01", HttpCompletionOption.ResponseHeadersRead);
            if(result.IsSuccessStatusCode)
            {
                using (StringReader reader = new StringReader(await result.Content.ReadAsStringAsync())) 
                {
                    while(reader.ReadLine() is string line)
                    {
                        var res = CsvParser.Parse(line, '"', ',');
                        Console.WriteLine(line);
                    }
                }
            }

            result = await client.GetAsync($@"https://192.168.2.157:5844/api/ExchangeRates/BaseCurrency/14/CounterCurrency/15/Latest", HttpCompletionOption.ResponseHeadersRead);

            if (result.IsSuccessStatusCode)
            {
                var exchangeRate = await result.Content.ReadFromJsonAsync<ExchangeRate>();
                Console.WriteLine($"{exchangeRate.StartDateTime} {exchangeRate.Value}");
            }
            else
            {
                Console.WriteLine("Failed");
            }
            
            Console.WriteLine("Hello, World!");
        }
    }
}
