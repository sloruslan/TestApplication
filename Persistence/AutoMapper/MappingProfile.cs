using Application.DTO.PowerUnit;
using Application.DTO.Station;
using AutoMapper;
using Domain.DTO;

namespace Persistence.AutoMapper.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreatePowerUnitRequest, PowerUnit>();
        CreateMap<UpdatePowerUnitRequest, PowerUnit>();
        CreateMap<PowerUnit, PowerUnitResponse>();


        CreateMap<CreateStationRequest, Station>();
        CreateMap<UpdateStationRequest, Station>();
        CreateMap<Station, StationResponse>();
    }

}