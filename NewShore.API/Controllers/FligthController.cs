using Microsoft.AspNetCore.Mvc;
using NewShore.Business.Interfaces;
using NewShore.DataAccess.Models;

namespace NewShore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FligthController : ControllerBase
    {
       

        private readonly ILogger<FligthController> _logger;
        private readonly IFlightBusiness _flightBusiness;

        public FligthController(ILogger<FligthController> logger, IFlightBusiness flightBusiness )
        {
            _logger = logger;
            _flightBusiness = flightBusiness;   
        }

        [HttpGet]
        [Route("GetCities")]
        public IActionResult GetCities() 
        {
            try
            {
                var result = _flightBusiness.GetCities();
                if (result == null)
                {
                    return NotFound(new { Mesage = "Vuelos no encontrados" });
                }
                else
                {
                    return Ok(new
                    {
                        Status = true,
                        Message = "Vuelos encontrados",
                        Result = result
                    });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetFligths")]
        public IActionResult GetFligths()
        {
            try
            {
                var result = _flightBusiness.GetFligths();
                if(result== null) 
                {
                    return NotFound(new { Mesage = "Vuelos no encontrados"});
                }
                else 
                {
                    return Ok(new {
                      Status = true,
                      Message = "Vuelos encontrados",
                      Result = result
                    });
                }
            }
            catch (Exception ex)
            {

                return BadRequest( new { Message = ex.Message});
            }
        }
        [HttpGet]
        [Route("GetRoutes")]
        public IActionResult GetRoutes([FromQuery] FlightRequest request)
        {
            try
            {
                var result = _flightBusiness.GetRoutes(request);
                if (result == null)
                {
                    return NotFound(new { Mesage = "Vuelos no encontrados" });
                }
                else
                {
                    return Ok(new
                    {
                        Status = true,
                        Message = "Vuelos encontrados",
                        Result = result
                    });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("ChangeCurrency")]
        public IActionResult ChangeCurrency(ExchangeAmount amount) 
        {
            if(ModelState.IsValid)
            {
                var result = _flightBusiness.ChangeCurrency(amount);
                if (result == null)
                {
                    return NotFound(new { Mesage = "No se pudo realizar la conversión" });
                }
                else
                {
                    return Ok(new
                    {
                        Status = true,
                        Message = "Conversión realizada.",
                        Result = result
                    });
                }
            }
            else 
            {

                return BadRequest(new { Message ="Error en la petición" });
            }
        }
    }
}