using System.Threading.Tasks;
using Autofac;

namespace Guesthouse.Services
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext _componentContext;

        public QueryDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }
        
        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            var handleType = typeof(IQueryHandler<,>)
                .MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = _componentContext.Resolve(handleType);

            return await handler.HandleAsync((dynamic) query);
        }
    }
}