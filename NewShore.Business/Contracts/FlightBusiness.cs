using NewShore.Business.Interfaces;
using NewShore.DataAccess.Interfaces;
using NewShore.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NewShore.Business.Contracts
{
    public class FlightBusiness: IFlightBusiness
    {
        private readonly IFlightData _flightData;
        public FlightBusiness(IFlightData flightData)
        {
            _flightData = flightData;
        }
        public Cities GetCities()
        {
            Cities cities = null;
            var flights = _flightData.GetFligths();
            if(flights != null) 
            {
                cities = new Cities();
                var origins = (from fly in flights select fly.DepartureStation).ToList().Distinct();
                var destinations = (from fly in flights select fly.ArrivalStation).ToList().Distinct();

                if (origins != null) cities.Origins = origins.ToList();
                if (destinations != null) cities.Destinations = destinations.ToList();
            }


            return cities;
        }

        public List<Root> GetFligths() 
        {
            return _flightData.GetFligths();
        }
        public Journey GetRoutes(FlightRequest request) 
        {
            var flights = _flightData.GetFligths();
            
            var flightsFull = flights.Where(a => a.DepartureStation == request.Origin && a.ArrivalStation == request.Destination).ToList();
            var flightsOrigin = (from fl in flights
                                where fl.DepartureStation == request.Origin 
                                select fl ).ToList();
            var flightsDestination = (from fly in flights
                                 where fly.ArrivalStation == request.Destination
                                 select fly).ToList();
            var result = new Journey();
            result.Origin = request.Origin;
            result.Destination = request.Destination;
            result.Price = 0;
            result.Flights = new List<Flight>();

            if(flightsFull != null) 
            {
                foreach(var flight in flightsFull) 
                {
                    result.Price= result.Price + flight.Price ;
                    result.Flights.Add(new Flight
                    {
                        Origin = flight.DepartureStation,
                        Destination = flight.ArrivalStation,
                        Price = flight.Price,
                        Transport = new Transport
                        {
                            FlightCarrier = flight.FlightCarrier,
                            FlightNumber= flight.FlightNumber,
                        }
                    });
                }
            }
            if(flightsDestination != null) 
            {
                foreach(var flys in flightsDestination) 
                {
                    if(flightsOrigin.Exists(a =>a.ArrivalStation == flys.DepartureStation))
                    {
                        var fliOrigin = flightsOrigin.Where(a => a.ArrivalStation == flys.DepartureStation).FirstOrDefault();   
                        
                        if(fliOrigin != null) 
                        {
                            result.Price = result.Price + fliOrigin.Price + flys.Price;
                            result.Flights.Add(new Flight
                            {
                                Origin = fliOrigin.DepartureStation,
                                Destination = fliOrigin.ArrivalStation,
                                Price = fliOrigin.Price,
                                Transport = new Transport
                                {
                                    FlightCarrier = fliOrigin.FlightCarrier,
                                    FlightNumber = fliOrigin.FlightNumber,
                                }
                            });
                            result.Flights.Add(new Flight
                            {
                                Origin = flys.DepartureStation,
                                Destination = flys.ArrivalStation,
                                Price = flys.Price,
                                Transport = new Transport
                                {
                                    FlightCarrier = flys.FlightCarrier,
                                    FlightNumber = flys.FlightNumber,
                                }
                            });
                        }
                       
                    }
                }
            }
           
            return result;
        }
        public ResponseAmount ChangeCurrency(ExchangeAmount amount)
        {
            return _flightData.ChangeCurrency(amount);
        }
    }
}
