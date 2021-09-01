using MediatR;

namespace CrossCuttingConcerns.Application.CQRS
{
    public interface IQuery<out T> : IRequest<T>
    {
        
    }
}