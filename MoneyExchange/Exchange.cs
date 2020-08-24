using System.Net;
using System.IO;
using System;
using Newtonsoft.Json.Linq;

namespace MoneyExchange
{
    /// <summary>
    /// This class is money currency rate and information class.
    /// </summary>
    public class Exchange
    {
       
        public Exchange()
        {
        }
        /// <summary>
        /// Get currency rate online.
        /// </summary>
        /// <param name="key">This should be rate key. i.e. USDTRY</param>
        /// <returns>Result of rate (provide by key)</returns>
        private double getExchange(string key)
        {
            //Url for using currency. It is free to use.
            string url = $"https://www.freeforexapi.com/api/live?pairs={key}";

            //JSON data reader.
            StreamReader reader = null;

            //Data -> have been read
            string read = "" ;
            try
            {
                //Request from api.
                WebRequest request = WebRequest.Create(new Uri(url));

                //Connection successfully, get response.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                //Read JSON data.
                reader = new StreamReader(response.GetResponseStream());

                //Store JSON data.
                read = reader.ReadToEnd();

                //Write the data into external files to use if connection does not exist.
                StreamWriter writer = new StreamWriter(key + ".json");
                writer.Write(read);
                writer.Close();
            }
            catch // catch any problem due to networking connection or IO problems. 
            {
                //check if currency files does exist or not.
                if (!File.Exists(key + ".json"))
                    //if not, return 0.0
                    return 0.0;

                //else read JSON data from the files. 
                reader = new StreamReader(key + ".json");
                read = reader.ReadToEnd();
            }
            //Create JSON data parser.
            JObject json = JObject.Parse(read);

            //Return rate of currency.
            return json.SelectToken("rates").SelectToken(key).Value<double>("rate");
        }

        public double USD_TO_TRY => getExchange("USDTRY");
        public double USD_TO_EUR => getExchange("USDEUR");
        public double USD_TO_GBP => getExchange("USDGBP");
        public double USD_TO_JPY => getExchange("USDJPY");

        public double EUR_TO_TRY => getExchange("USDTRY") / getExchange("USDEUR");
        public double EUR_TO_USD => getExchange("EURUSD");
        public double EUR_TO_GBP => getExchange("EURGBP");
        public double EUR_TO_JPY => getExchange("USDJPY") / getExchange("USDEUR");

        public double TRY_TO_USD => 1 / USD_TO_TRY;
        public double TRY_TO_EUR => 1 / EUR_TO_TRY;
        public double TRY_TO_GBP => USD_TO_GBP / USD_TO_TRY;
        public double TRY_TO_JPY => USD_TO_JPY / USD_TO_TRY;


        public double GBP_TO_USD => getExchange("GBPUSD");
        public double GBP_TO_EUR => 1 / EUR_TO_GBP;
        public double GBP_TO_TRY => USD_TO_TRY / USD_TO_GBP;
        public double GBP_TO_JPY => USD_TO_JPY / USD_TO_GBP;


        public double JPY_TO_USD => 1 / USD_TO_JPY;
        public double JPY_TO_EUR => 1 / EUR_TO_JPY;
        public double JPY_TO_GBP => 1 / GBP_TO_JPY;
        public double JPY_TO_TRY => 1 / TRY_TO_JPY;


    }
}