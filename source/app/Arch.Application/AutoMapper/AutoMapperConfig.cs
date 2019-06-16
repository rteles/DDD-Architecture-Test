using Arch.Application.AutoMapper.Mappers;
using AutoMapper;

namespace Arch.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<RequestToDataTransferMappingProfile>();
                x.AddProfile<DataTransferToResultMappingProfile>();
            });
        }
    }
}