using Microsoft.Extensions.Configuration;
using NewShore.DataAccess.Interfaces;
using NewShore.DataAccess.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NewShore.DataAccess.Contracts
{
    public class FlightData: IFlightData
    {
        private readonly IConfiguration _config;
        public FlightData(IConfiguration config)
        {
            _config = config;
        }

        public List<Root> GetFligths()
        {
            try
            {
                var client = new RestClient(_config.GetSection("ColectionData").Value.ToString());
                var request = new RestRequest();
                var response = client.Get(request);
                var fligths = JsonSerializer.Deserialize<List<Root>>(response.Content);
                return fligths;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public ResponseAmount ChangeCurrency(ExchangeAmount amount)
        {
            try
            {
                var client = new RestClient("https://api.apilayer.com/exchangerates_data/convert?to=" + amount.To + "&from=" + amount.From + "&amount=" + amount.Amount + "");


                var request = new RestRequest();
                request.Timeout = -1;
                request.AddHeader("apikey", "Ve6B2AT12aNStntRWyg1qY6EfoPy1HW4");


                var response = client.Get(request);
                var result = JsonSerializer.Deserialize<ResponseAmount>(response.Content);
                return result;
            }
            catch (Exception ex)
            {

                return null;
            }
            
           
        }
    }
}
