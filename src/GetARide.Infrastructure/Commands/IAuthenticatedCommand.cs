using System;
using GetARide.Infrastructure.Commands.User;

namespace GetARide.Infrastructure.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
         Guid UserId{get;set;}
    }
}