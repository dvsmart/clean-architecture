using Q.Domain;

namespace Q.Infrastructure.Mappings
{
    public interface IOutputConverter
    {
        T Map<T>(object source);

    }
}