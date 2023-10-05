using Domain.Entities;

namespace Application.Interfaces;

public interface IApplicationHandler<T, R> where T : class where R : class
{
    Task<R> Handle(T request);
}