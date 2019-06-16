using AutoMapper;

namespace Arch.Application.AutoMapper.Mappers
{
    public class RequestToDataTransferMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<DataTypes.Request.AddUserRequest, Core.Entities.User>();
        }
    }
}