using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.PowerUnit
{
    public class FilteringPowerUnitRequest
    {
        [BindProperty(Name = "id")]
        public long? Id { get; set; }

        [BindProperty(Name = "station_id")]
        public long? StationId { get; set; }

        [BindProperty(Name = "name")]
        public string? Name { get; set; }

        [BindProperty(Name = "created_at")]
        public DateTime? CreatedAt { get; set; }

        [BindProperty(Name = "date_of_next_service")]
        public DateTime? DateOfNextService { get; set; }

        [BindProperty(Name = "count_sensor")]
        public long? CountSensor { get; set; }
    }
}
