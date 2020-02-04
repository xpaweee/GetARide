using System;
using AutoMapper;
using GetARide.Core.Domain;
using GetARide.Core.Repositories;
using GetARide.Infrastructure.DTO;

namespace GetARide.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserDto GetUser(string email)
        {
           var user = _userRepository.GetUser(email);
           if(user is { })
                return _mapper.Map<User,UserDto>(user);

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