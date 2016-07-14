using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCollections_EasyDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new EasyDictionary<string, string>();
            d.Add("salinger", "rye");
            d.Add("allen", "wheat");
            d.Add("reno", "vassabi");
            d.Add("bradbury", "dandelion");
            d.Print();

            try
            {
                d.Add("bradbury", "fahrenheit");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Exception caught. {0}", ex.Message);
            }

            try
            {
                d.Remove("freud");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Exception caught. {0}", ex.Message);
            }

            d.Remove("reno");
            d.Print();

            Console.WriteLine("For key = \"allen\", value = {0}.", d["allen"]);

            d["saint-exupery"] = "baobab";
            Console.WriteLine("For key = \"saint-exupery\", value = {0}.", d["saint-exupery"]);
            
            try
            {
                Console.WriteLine("For key = \"clover\", value = {0}.", d["clover"]);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            string value = "";
            if (d.TryGetValue("clover", out value))
            {
                Console.WriteLine("For key = \"clover\", value = {0}.", value);
            }
            else
            {
                Console.WriteLine("Key = \"clover\" is not found.");
            }

            if (d.TryGetValue("allen", out value))
            {
                Console.WriteLine("For key = \"allen\", value = {0}.", value);
            }
            else
            {
                Console.WriteLine("Key = \"allen\" is not found.");
            }

            if (!d.ContainsKey("irish"))
            {
                d.Add("irish", "clover");
                Console.WriteLine("Value added for key = \"irish\": {0}", d["irish"]);
            }
            d.Print();

            Console.ReadLine();
        }
    }
}
