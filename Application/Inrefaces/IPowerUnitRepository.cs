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
        Task<PowerUnit> CreateAsync(CreatePowerUnitRequest request);
        Task DeleteAsync(long id);
        Task<IEnumerable<PowerUnit>> GetAsync(FilteringPowerUnitRequest filteringModel);
        Task<PowerUnit> GetAsync(long id);
        Task<PowerUnit> UpdateAsync(long id, UpdatePowerUnitRequest request);
    }
}
