using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewShore.DataAccess.Models
{
    public class ExchangeAmount
    {
        [Required(ErrorMessage = "El campo monto es requerido")]
        [JsonPropertyName("amount")]
        public double Amount { get; set; }
        [Required(ErrorMessage = "El campo Desde es requerido")]
        [MaxLength(3, ErrorMessage = "El campo debe tener 3 carateres 'COP'")]
        [MinLength(3, ErrorMessage = "El campo debe tener 3 carateres 'COP'")]
        [JsonPropertyName("from")]
        public string From { get; set; }
        [Required(ErrorMessage = "El campo A es requerido")]
        [MaxLength(3, ErrorMessage = "El campo debe tener 3 carateres 'USD'")]
        [MinLength(3, ErrorMessage = "El campo debe tener 3 carateres 'USD'")]
        [JsonPropertyName("to")]
        public string To { get; set; }
    }
}
