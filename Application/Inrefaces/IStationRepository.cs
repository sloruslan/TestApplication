using Application.DTO.PowerUnit;
using Application.DTO.Station;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inrefaces
{
    public interface IStationRepository
    {
        Task<Station> CreateAsync(CreateStationRequest request);
        Task DeleteAsync(long id);
        Task<IEnumerable<Station>> GetAsync(FilteringStationRequest filteringModel);
        Task<Station> GetAsync(long id);
        Task<Station> UpdateAsync(long id, UpdateStationRequest request);
    }
}
