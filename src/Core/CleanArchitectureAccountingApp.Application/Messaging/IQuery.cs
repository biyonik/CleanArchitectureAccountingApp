using MediatR;

namespace CleanArchitectureAccountingApp.Application.Messaging;

public interface IQuery<out TResponse>: IRequest<TResponse>
{
    
}