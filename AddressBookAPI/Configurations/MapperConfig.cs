using AddressBookAPI.Models.CoreModels;
using AddressBookAPI.Models.DataModels;
using AutoMapper;
using System.Text.Json;

namespace AddressBookAPI.Configurations
{
    public class MapperConifg
    {
        public Mapper GetMapper()
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Contact, ContactDataModel>()
                         .ForMember(dest => dest.Address, opt => opt.MapFrom(src => JsonSerializer.Serialize(src.Address,new JsonSerializerOptions())))
                         .ReverseMap()
                         .ForMember(src => src.Address, opt => opt.MapFrom(dst => JsonSerializer.Deserialize<Address>(dst.Address, new JsonSerializerOptions()))));
                           

            return new Mapper(config);

        }

    }

}
