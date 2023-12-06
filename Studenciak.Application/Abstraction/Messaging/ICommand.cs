using MediatR;

namespace Application.Abstraction.Messaging;

//without response
public interface ICommand : IRequest {}

//with response
public interface ICommand<TResponse> : IRequest<TResponse> {}