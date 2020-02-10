using System;
using GetARide.Infrastructure.DTO;

namespace GetARide.Infrastructure.Services
{
    public interface IJwtHandler
    {
         JwtDto CreateToken(string email,string role);
    }
}