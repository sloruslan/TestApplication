using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.PowerUnit
{
    public class PowerUnitResponse
    {
        public long Id { get; set; }
        public long StationId { get; set; }
        public string Name { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime DateOfNextService { get; set; }
        public long CountSensor { get; set; }
    }
}
