using MediatR;

namespace CrossCuttingConcerns.Application.CQRS
{
    public interface ICommand<out T> : IRequest<T>
    {
        
    }
}