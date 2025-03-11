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
        Task<StationResponse> CreateAsync(CreateStationRequest request);
        Task DeleteAsync(long id);
        Task<IEnumerable<StationResponse>> GetAsync(FilteringStationRequest filteringModel);
        Task<StationResponse> GetAsync(long id);
        Task<StationResponse> UpdateAsync(long id, UpdateStationRequest request);
    }
}
