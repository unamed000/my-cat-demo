using System.Threading.Tasks;

namespace MyOrg.Core.UseCase
{
    public interface IAsynchronousUseCase<TArguments, TResult>
    {
        Task<TResult> Execute(TArguments args);
    }

    public abstract class AsynchronousUseCase<TArguments, TResult> : IAsynchronousUseCase<TArguments, TResult>
    {
        public abstract Task<TResult> Execute(TArguments args);
    }
}