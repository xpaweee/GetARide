using System;
using GetARide.Infrastructure.Commands.User;

namespace GetARide.Infrastructure.Commands.Driver
{
    public class CreateDriverRoute : ICommand
    {
        public Guid UserId{get;set;}
        public string Name{get;set;}
        public double StartLatitude{get;set;}
        public double StartLongtitude{get;set;}
        public double EndLatitude{get;set;}
        public double EndLongtitude{get;set;}
    }
}