using System;
using GetARide.Infrastructure.Commands.User;

namespace GetARide.Infrastructure.Commands.Driver
{
    public class DeleteDriverRoute : AuthenticatedCommandBase
    {
        public string Name{get;set;}
    }
}