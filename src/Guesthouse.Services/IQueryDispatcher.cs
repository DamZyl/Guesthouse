using System.Threading.Tasks;

namespace Guesthouse.Services
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}