using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class Station
    {
        public long Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime CreatedAt { get; set; }

        public List<PowerUnit> PowerUnits { get; set; } = new();
    }
}
