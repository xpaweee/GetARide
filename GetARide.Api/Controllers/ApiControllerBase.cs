using GetARide.Infrastructure.Commands.User;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace GetARide.Api.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("[controller")]
    public abstract class ApiControllerBase : Controller
    {
        protected readonly ICommandDispatcher CommandDispatcher;
        protected ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;
        }
    }
}