using System;
using System.Threading.Tasks;

namespace GetARide.Infrastructure.Services
{
    public interface IHandler : IService
    {
         IHandlerTask Run(Func<Task> run);
         IHandlerTaskRunner Validate(Func<Task> validate);
         Task ExecuteAllAsync();
    }
}