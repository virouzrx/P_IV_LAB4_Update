using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_Lab4_update
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var stopWatch = new Stopwatch();

            var google = new Website("https://google.pl");
            var ath = new Website("https://ath.bielsko.pl");
            var fb = new Website("https://facebook.com");
            var wiki = new Website("https://en.wikipedia.org/");
            var anyapi = new Website("https://any-api.com");
            var plany = new Website("https://plany.ath.bielsko.pl");

            var tasks = new List<Task<IRestResponse>>();

            stopWatch.Start();

            tasks.Add(google.DownloadAsync("/"));
                Console.WriteLine(stopWatch.Elapsed);
            tasks.Add(ath.DownloadAsync("/"));
                Console.WriteLine(stopWatch.Elapsed);
            tasks.Add(fb.DownloadAsync("/"));
                Console.WriteLine(stopWatch.Elapsed);
            tasks.Add(wiki.DownloadAsync("/wiki/.NET_Core"));
                Console.WriteLine(stopWatch.Elapsed);
            tasks.Add(anyapi.DownloadAsync("/wiki/.NET_Core"));
                Console.WriteLine(stopWatch.Elapsed);
            tasks.Add(plany.DownloadAsync("/"));
                Console.WriteLine(stopWatch.Elapsed);

            Console.WriteLine(Task.WhenAny(tasks).Result.Result.Content); // lub -> Task.WhenAll(tasks).GetAwaiter().GetResult();
            Console.WriteLine(stopWatch.Elapsed);

            var htmlCodes = await Task.WhenAll(tasks); //potrzebny async, tak samo main musi być wtedy async
            foreach (var item in htmlCodes)
            {
                Console.WriteLine(item.Content);
            }

            Console.WriteLine(stopWatch.Elapsed);
            stopWatch.Stop();
        }
    }
}
