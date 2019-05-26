using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

namespace All_mtg_card_names
{
    class Program
    {
        static void Main(string[] args)
        {
            var webRequest = WebRequest.Create(@"https://mtgjson.com/json/AllCards.json");
            var strContent = new StreamReader(webRequest.GetResponse().GetResponseStream()).ReadToEnd();

            JObject jObject = JObject.Parse(strContent);

            Console.WriteLine(jObject);
        }
    }
}
