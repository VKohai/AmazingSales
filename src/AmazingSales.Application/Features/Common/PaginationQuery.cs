using MediatR;

namespace AmazingSales.Application.Features.Common;

public record PaginationQuery<T> : IRequest<IEnumerable<T>>
{
    public int Count { get; set; }
    public int Offset { get; set; }

    public PaginationQuery()
    {
    }

    public PaginationQuery(int count, int offset) => (Count, Offset) = (count, offset);
}