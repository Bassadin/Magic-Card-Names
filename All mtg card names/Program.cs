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

            JObject cardData = JObject.Parse(strContent);
            JEnumerable<JToken> objectList = cardData.Children();

            StreamWriter fileStreamWriter = new StreamWriter(@"C:\Users\basti\Downloads\mtg_card_names.txt");

            foreach (JToken cardDataObject in objectList)
            {
                String referenceValue = cardDataObject.First.SelectToken("name").ToString();
                fileStreamWriter.WriteLine($"\"{referenceValue}\", \"{referenceValue}\"");
            }
        }
    }
}
