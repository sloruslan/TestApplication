using Application.DTO.PowerUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Station
{
    public class StationResponse
    {
        public long Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<PowerUnitResponse> PowerUnits { get; set; } = new();
    }
}
