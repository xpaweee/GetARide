using System;
using GetARide.Infrastructure.Commands.User;

namespace GetARide.Infrastructure.Commands.Driver
{
    public class DeleteDriverRoute : ICommand
    {
        public Guid UserId {get;set;}
        public string Name{get;set;}
    }
}