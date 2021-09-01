using MediatR;

namespace CrossCuttingConcerns.Application.CQRS
{
    public interface ICommandHandler<in T, TR> : IRequestHandler<T, TR> where T : ICommand<TR>
    {
    }
}