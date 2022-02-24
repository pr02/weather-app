using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.Json;

/*
For this can you I ask you to create your own program in Python, JavaScript or .NET that uses https://www.weatherapi.com/ to get the weather of all major airports
in New Zealand (you decide which ones are major). Please do not use a SDK and make sure you comment your code to show the process you went through.

Program should at least print out:
·        Airport Name and Region
·        Temperature in Celsius
·        The Weather Condition
·        Wind in kph

You could go further if you wish and look at creating a nice GUI or webpage for this info, but printing it out to screen is fine.
Commit your code to a new GitHub repository (If you don't already have a GitHub account, create one) 
Email me back a link to the GitHub repository.

Any question about this please email me back. If you could have something back by Friday the 25th that would be great.
*/

namespace WeatherApp
{
    class Program
    {
        // Creates the base HttpClient object that will be used throughout for managing requests with the API.
        private static readonly HttpClient client = new HttpClient();
        // Query that is parsed to the stream method for execution.

        
        public static async Task Main(string[] args)
        {
            await ProcessAirport();
        }


        private static async Task ProcessAirport() 
        {
            // Array of coordinates to major airports in New Zealand (From left to right Auckland, Rotorua, Wellington, Christchurch, Queenstown).
            string[] airportCoords = {"-36.87,174.77", "-38.14,176.25", "-41.3,174.78", "-43.53,172.63", "-45.01,168.4"};
                

            // Add the relevant header data to the request being sent.
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "WeatherAPI New Zealand Airport Monitor");

            // Loop through each location in the array and send each one to the API for querying.
            foreach (string ap in airportCoords)
            {
                // Query API with key and relevant array entry.
                var stringTask = client.GetStringAsync("http://api.weatherapi.com/v1/current.json?key=df28f83d9e144f81bcd34045221802&q=" + ap + "&aqi=no");
                // var current = await JsonSerializer.DeserializeAsync<List<Current>>(await stringTask);
                var msg = await stringTask;
                Console.WriteLine(msg);
            }
            
            /*
                Despite my efforts, I could not get the Json class to Deserialize the call from the API without spitting out all
                kinds of errors. This was rather unfortunate as it means that I can only get the output in its raw form. If I had
                a little more time I surely would have had it going though.

                The other file airport.cs contains the JSON property values that I was intending to pull from the response if it actually
                gave me what I wanted.

                Thank you for giving me this challenge, it was tougher than I expected!
            
            */

            // Console.WriteLine(current.LastUpdated);
            // Console.WriteLine(current.LastUpdatedEpoch);
            // Console.WriteLine(current.TempC);
            // Console.WriteLine(current.WindKph);
            
            

        }
    }
}