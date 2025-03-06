using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class PowerUnit
    {
        public long Id { get; set; }
        public long StationId { get; set; }
        public string Name { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public DateTime DateOfNextService { get; set; }
        public long CountSensor { get; set; }

        public Station Station { get; set; } = new Station();
    }
}
