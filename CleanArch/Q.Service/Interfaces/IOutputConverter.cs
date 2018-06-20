namespace Q.Service.Interfaces
{
    public interface IOutputConverter
    {
        T Map<T>(object source);
    }
}
