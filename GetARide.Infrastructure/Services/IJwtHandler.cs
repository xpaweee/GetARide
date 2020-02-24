using System;
using GetARide.Infrastructure.DTO;

namespace GetARide.Infrastructure.Services
{
    public interface IJwtHandler
    {
         JwtDto CreateToken(Guid userId,string role);
    }
}