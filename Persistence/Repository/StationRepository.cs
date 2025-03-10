using Application.DTO.Station;
using Application.Inrefaces;
using AutoMapper;
using Domain.DTO;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Extensions;
using Persistence.Extensions;

namespace Persistence.Repository
{
    public class StationRepository : IStationRepository
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly IMapper _mapper;
        public StationRepository(IDbContextFactory dbContextFactory, IMapper mapper)
        {
            _dbContextFactory = dbContextFactory;
            _mapper = mapper;
        }

        public async Task<StationResponse> CreateAsync(CreateStationRequest request)
        {
            await using var context = _dbContextFactory.CreateDbContext();
            {
                var newEntity = _mapper.Map<Station>(request);
                context.Station.Add(newEntity);
                await context.SaveChangesAsync();

                return _mapper.Map<StationResponse>(newEntity);
            }  
        }

        public async Task DeleteAsync(long id)
        {
            await using (var db = _dbContextFactory.CreateDbContext())
            {
                var entity = await db.Station.FirstOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                {
                    throw new EntityNotFindException("Объект не найден!");
                }
                db.Station.Remove(entity);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<StationResponse>> GetAsync(FilteringStationRequest filteringModel)
        {
            await using (var db = _dbContextFactory.CreateDbContext())
            {

                var query = db.Station.AsQueryable();

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

                if (filteringModel.Sort.CheckParameters())
                {
                    query = query.OrderBy(filteringModel.Sort!.OrderBy!, filteringModel.Sort.Ordering);
                }

                var entities = await query.ToPaginatedListAsync(filteringModel.Limit, filteringModel.Offset);


                var res = entities.ToList();
                return _mapper.Map<List<StationResponse>>(res);
            }
        }

        public async Task<StationResponse> GetAsync(long id)
        {
            await using (var db = _dbContextFactory.CreateDbContext())
            {
                var entity = await db.Station
                    .Include(x => x.PowerUnits)
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                {
                    throw new EntityNotFindException("Объект не найден!");
                }
                return _mapper.Map<StationResponse>(entity);
            }   
        }

        public async Task<StationResponse> UpdateAsync(long id, UpdateStationRequest request)
        {
            await using (var db = _dbContextFactory.CreateDbContext())
            {
                var entity = await db.Station.FirstOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                {
                    throw new EntityNotFindException("Объект не найден!");
                }

                _mapper.Map(request, entity);
                db.Update(entity);
                await db.SaveChangesAsync();

                return _mapper.Map<StationResponse>(entity);
            }
        }
    }
}
