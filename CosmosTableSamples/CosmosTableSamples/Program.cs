using Microsoft.Azure.Cosmos.Table;
using System;

namespace CosmosTableSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Azure Cosmos Table Samples");
            BasicSamples basicSamples = new BasicSamples();
            basicSamples.RumSample().Wait();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.Read(); 
        }
    }
}
