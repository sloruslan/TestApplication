using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTO.Station
{
    public class UpdateStationRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;
    }
}
