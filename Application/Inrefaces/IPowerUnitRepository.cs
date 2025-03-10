using Application.DTO.PowerUnit;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Inrefaces
{
    public interface IPowerUnitRepository
    {
        Task<PowerUnitResponse> CreateAsync(CreatePowerUnitRequest request);
        Task DeleteAsync(long id);
        Task<IEnumerable<PowerUnitResponse>> GetAsync(FilteringPowerUnitRequest filteringModel);
        Task<PowerUnitResponse> GetAsync(long id);
        Task<PowerUnitResponse> UpdateAsync(long id, UpdatePowerUnitRequest request);
    }
}
