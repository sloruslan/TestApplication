using Application.DTO.PowerUnit;
using Application.Inrefaces;
using AutoMapper;
using Domain.DTO;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class PowerUnitRepository : IPowerUnitRepository
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly IMapper _mapper;
        public PowerUnitRepository(IDbContextFactory dbContextFactory, IMapper mapper)
        {
            _dbContextFactory = dbContextFactory;
            _mapper = mapper;
        }

        public async Task<PowerUnit> CreateAsync(CreatePowerUnitRequest request)
        {
            await using var context = _dbContextFactory.CreateDbContext();

            var newEntity = _mapper.Map<PowerUnit>(request);
            context.PowerUnit.Add(newEntity);
            context.SaveChanges();

            return newEntity;
 
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PowerUnit>> GetAsync(FilteringPowerUnitRequest filteringModel)
        {
            using (var db = _dbContextFactory.CreateDbContext())
            {
                var t = db.PowerUnit.ToList();
            }
            throw new NotImplementedException();
        }

        public Task<PowerUnit> GetAsync(long id)
        {
            using (var db = _dbContextFactory.CreateDbContext())
            {
                var t = db.PowerUnit.ToList();
            }
            throw new NotImplementedException();
        }

        public Task<PowerUnit> UpdateAsync(long id, UpdatePowerUnitRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
