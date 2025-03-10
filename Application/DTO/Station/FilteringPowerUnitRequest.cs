using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Station
{
    public class FilteringStationRequest
    {
        [BindProperty(Name = "id")]
        public long? Id { get; set; }

        [BindProperty(Name = "name")]
        public string? Name { get; set; }

        [BindProperty(Name = "created_at")]
        public DateTime? CreatedAt { get; set; }
    }
}
