using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTO.PowerUnit
{
    public class CreatePowerUnitRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("station_id")]
        public long StationId { get; set; }

        [JsonPropertyName("date_of_next_service")]
        public DateTime DateOfNextService { get; set; }

        [JsonPropertyName("count_sensor")]
        public long CountSensor { get; set; }
    }
}
