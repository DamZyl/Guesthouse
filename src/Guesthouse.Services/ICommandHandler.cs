using System.Threading.Tasks;

namespace Guesthouse.Services
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}