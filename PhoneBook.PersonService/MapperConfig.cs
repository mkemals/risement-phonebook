using AutoMapper;

namespace PhoneBook.PersonService
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Model.Person, DTO.Person>();
            }));
        }
    }
}
