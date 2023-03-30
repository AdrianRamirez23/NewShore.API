using NewShore.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShore.Business.Interfaces
{
    public interface IFlightBusiness
    {
        Cities GetCities();
        List<Root> GetFligths();
        Journey GetRoutes(FlightRequest request);
        ResponseAmount ChangeCurrency(ExchangeAmount amount);
    }
}
