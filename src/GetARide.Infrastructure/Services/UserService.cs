using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GetARide.Core.Domain;
using GetARide.Core.Repositories;
using GetARide.Infrastructure.DTO;
using GetARide.Infrastructure.Exceptions;

namespace GetARide.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter; 
        public UserService(IUserRepository userRepository, IMapper mapper, IEncrypter encrypter)
        {
            _encrypter = encrypter;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserAsync(string email)
        {
            var user = await _userRepository.GetUserAsync(email);
            return _mapper.Map<User, UserDto>(user);
           
        }
            public async Task<IEnumerable<UserDto>> BrowseAsync()
        {
            var drivers = await _userRepository.BrowseAsync();

            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(drivers);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetUserAsync(email);
            if (user == null)
                throw new ServiceException(Exceptions.ErrorCodes.InvalidCredentials,"Invalid credentials");
            var hash = _encrypter.GetHash(password,user.Salt);
            if(user.Password == hash)
                return;
            throw new ServiceException(Exceptions.ErrorCodes.InvalidCredentials,$"Invalid credentials");
        }

        public async Task RegisterAsync(string email, string username, string password)
        {
            var user = await _userRepository.GetUserAsync(email);
            if (user is { })
                throw new ServiceException(Exceptions.ErrorCodes.EmailInUser,$"User with email: '{email}' already exists.");

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password,salt);
            user = new User(Guid.NewGuid(),email, username, "admin",hash, salt);
            await _userRepository.AddAsync(user);
        }
    }
}