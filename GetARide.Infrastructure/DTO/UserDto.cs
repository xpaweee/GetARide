using System;

namespace GetARide.Infrastructure.DTO
{
    public class UserDto
    {
        
        public Guid Id{get;  set;}
        public string Email { get;  set; }
        public string Username { get;  set; }
        public DateTime CreatedAt { get;  set; }
    }
}