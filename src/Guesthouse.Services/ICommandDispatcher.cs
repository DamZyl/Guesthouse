using System.Threading.Tasks;

namespace Guesthouse.Services
{
    public interface ICommandDispatcher
    {
        Task SendAsync<T>(T command) where T : ICommand;
    }
}