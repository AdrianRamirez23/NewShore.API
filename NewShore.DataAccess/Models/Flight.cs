using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewShore.DataAccess.Models
{
    public class Flight
    {
        [JsonPropertyName("transport")]
        public Transport Transport { get; set; }
        [JsonPropertyName("origin")]
        [MaxLength(3, ErrorMessage = "El campo tiene una longitud máxima de 3 caracteres")]
        [MinLength(3, ErrorMessage = "El campo tiene una longitud mínima de 3 caracteres")]
        public string Origin { get; set; }
        [JsonPropertyName("destination")]
        [MaxLength(3, ErrorMessage = "El campo tiene una longitud máxima de 3 caracteres")]
        [MinLength(3, ErrorMessage = "El campo tiene una longitud mínima de 3 caracteres")]
        public string Destination { get; set; }
        [JsonPropertyName("price")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
    }
}
