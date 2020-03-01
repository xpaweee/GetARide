using System;
using System.Collections.Generic;

namespace GetARide.Core.Domain
{
    public class Passanger
    {
        public Guid Id{get;protected set;}
        public Guid UserId{get;protected set;}
        public Node Address{get;protected set;}
    }
}