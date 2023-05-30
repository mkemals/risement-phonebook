using AutoMapper;

namespace PhoneBook.ReportService
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Model.ReportRequest, DTO.ReportRequest>();
            }));
        }
    }
}
