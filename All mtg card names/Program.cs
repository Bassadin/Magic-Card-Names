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

            String resultString = "";

            JObject cardData = JObject.Parse(strContent);
            JEnumerable<JToken> objectList = cardData.Children();

            foreach (JToken cardDataObject in objectList)
            {
                Console.WriteLine(cardDataObject.First.First);
                resultString += cardDataObject.First + ", ";
            }


            Console.WriteLine(resultString);
        }
    }
}
