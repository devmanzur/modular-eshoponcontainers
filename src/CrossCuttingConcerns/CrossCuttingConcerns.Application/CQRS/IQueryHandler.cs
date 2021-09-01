using MediatR;

namespace CrossCuttingConcerns.Application.CQRS
{
    public interface IQueryHandler<in T, TR> : IRequestHandler<T, TR> where T : IQuery<TR>
    {
    }
}