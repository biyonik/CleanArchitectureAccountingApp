using MediatR;

namespace CleanArchitectureAccountingApp.Application.Messaging;

public interface ICommand<out TResponse>: IRequest<TResponse>
{
}