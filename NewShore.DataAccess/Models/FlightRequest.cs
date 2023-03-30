using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewShore.DataAccess.Models
{
    public class FlightRequest
    {
        [JsonPropertyName("origin")]
        [Required(ErrorMessage ="El origen es un dato obligatorio")]
        [MaxLength(3, ErrorMessage = "El campo origen tiene una longitud máxima de 3 caracteres")]
        [MinLength(3, ErrorMessage = "El campo origen tiene una longitud mínima de 3 caracteres")]
        public string Origin { get; set; }
        [JsonPropertyName("destination")]
        [Required(ErrorMessage = "El destino es un dato obligatorio")]
        [MaxLength(3, ErrorMessage = "El campo destino tiene una longitud máxima de 3 caracteres")]
        [MinLength(3, ErrorMessage = "El campo destino tiene una longitud mínima de 3 caracteres")]
        public string Destination { get; set; }
    }
}
