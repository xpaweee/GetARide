using System;
using System.Threading.Tasks;

namespace GetARide.Infrastructure.Services
{
    public interface IHandlerTaskRunner
    {
           IHandlerTask Run(Func<Task> run);
    }
}