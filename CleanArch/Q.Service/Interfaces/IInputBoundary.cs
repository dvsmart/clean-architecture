using System.Threading.Tasks;

namespace Q.Service.Interfaces
{
    public interface IInputBoundary<T>
    {
        Task Process(T input);

    }
}
