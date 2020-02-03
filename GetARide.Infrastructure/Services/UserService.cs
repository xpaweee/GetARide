using System;
using GetARide.Core.Domain;
using GetARide.Core.Repositories;
using GetARide.Infrastructure.DTO;

namespace GetARide.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto GetUser(string email)
        {
           var user = _userRepository.GetUser(email);
           if(user is { })
           {
                return new UserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email.ToLowerInvariant()

                };
            }

            throw new Exception("User already exists."); 
          
        }

        public void Register(string email, string username, string password)
        {
           var user = _userRepository.GetUser(email);
           if(user is {})
           {
               throw new Exception("User already exists."); 
           }
            //random string
           var salt = Guid.NewGuid().ToString("N");
           user = new User(email,username,password,salt);
           _userRepository.Add(user);
        }
    }
}