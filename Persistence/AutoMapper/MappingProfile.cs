using Application.DTO.PowerUnit;
using AutoMapper;
using Domain.DTO;

namespace Persistence.AutoMapper.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreatePowerUnitRequest, PowerUnit>();
    }

}