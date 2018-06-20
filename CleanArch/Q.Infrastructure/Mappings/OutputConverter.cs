using AutoMapper;

namespace Q.Infrastructure.Mappings
{
    public class OutputConverter : IOutputConverter
    {
        private readonly IMapper mapper;

        public OutputConverter()
        {
            //mapper = new MapperConfiguration(cfg => 
            //{
            //    cfg.AddProfile<TaskProfile>();
            //    cfg.AddProfile<MenuProfile>();
            //})
            //.CreateMapper();
        }

        public T Map<T>(object source)
        {
            T model = mapper.Map<T>(source);
            return model;
        }
    }
}
