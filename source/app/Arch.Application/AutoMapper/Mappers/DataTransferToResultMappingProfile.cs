using AutoMapper;

namespace Arch.Application.AutoMapper.Mappers
{
    public class DataTransferToResultMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Core.Entities.User, Application.DataTypes.Result.UserResult>();
        }
    }
}