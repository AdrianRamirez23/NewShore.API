using NewShore.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShore.DataAccess.Interfaces
{
    public interface IFlightData
    {
        List<Root> GetFligths();
        ResponseAmount ChangeCurrency(ExchangeAmount amount);
    }
}
