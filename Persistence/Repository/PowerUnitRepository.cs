using Application.DTO.PowerUnit;
using Application.DTO.Station;
using Application.Inrefaces;
using AutoMapper;
using Domain.DTO;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Extensions;
using Persistence.Extensions;

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

        public async Task<PowerUnitResponse> CreateAsync(CreatePowerUnitRequest request)
        {
            await using (var context = _dbContextFactory.CreateDbContext())
            {
                var newEntity = _mapper.Map<PowerUnit>(request);
                context.PowerUnit.Add(newEntity);
                await context.SaveChangesAsync();

                return _mapper.Map<PowerUnitResponse>(newEntity);
            }
        }

        public async Task DeleteAsync(long id)
        {
            await using (var db = _dbContextFactory.CreateDbContext())
            {
                var entity = await db.PowerUnit.FirstOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                {
                    throw new EntityNotFindException("Объект не найден!");
                }
                db.PowerUnit.Remove(entity);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PowerUnitResponse>> GetAsync(FilteringPowerUnitRequest filteringModel)
        {
            await using (var db = _dbContextFactory.CreateDbContext())
            {

                var query = db.PowerUnit.AsQueryable();

                if (filteringModel.Id.HasValue)
                {
                    query = query.Where(x => filteringModel.Id == x.Id);
                }

                if (filteringModel.Name != null)
                {
                    query = query.Where(x => filteringModel.Name == x.Name);
                }

                if (filteringModel.CreatedAt.HasValue)
                {
                    query = query.Where(x => filteringModel.CreatedAt == x.CreatedAt);
                }

                if (filteringModel.StationId.HasValue)
                {
                    query = query.Where(x => filteringModel.StationId == x.StationId);
                }

                if (filteringModel.DateOfNextService.HasValue)
                {
                    query = query.Where(x => filteringModel.DateOfNextService == x.DateOfNextService);
                }

                if (filteringModel.CountSensor.HasValue)
                {
                    query = query.Where(x => filteringModel.CountSensor == x.CountSensor);
                }

                if (filteringModel.Sort.CheckParameters())
                {
                    query = query.OrderBy(filteringModel.Sort!.OrderBy!, filteringModel.Sort.Ordering);
                }

                var entities = await query.ToPaginatedListAsync(filteringModel.Limit, filteringModel.Offset);


                var res = entities.ToList();
                return _mapper.Map<List<PowerUnitResponse>>(res);
            }
        }

        public async Task<PowerUnitResponse> GetAsync(long id)
        {
            using (var db = _dbContextFactory.CreateDbContext())
            {
                var res = db.PowerUnit.FirstOrDefault(x => x.Id == id);
                return _mapper.Map<PowerUnitResponse>(res);
            }
            
        }

        public async Task<PowerUnitResponse> UpdateAsync(long id, UpdatePowerUnitRequest request)
        {
            await using (var db = _dbContextFactory.CreateDbContext())
            {
                var entity = await db.PowerUnit.FirstOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                {
                    throw new EntityNotFindException("Объект не найден!");
                }

                _mapper.Map(request, entity);
                db.Update(entity);
                await db.SaveChangesAsync();

                return _mapper.Map<PowerUnitResponse>(entity);
            }
        }
    }
}
