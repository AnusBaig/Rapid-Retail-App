using RapidRetail.Domain.Aggregates;
using RapidRetail.Domain.Entities;
using RapidRetail.Domain.Repositories;
using RapidRetail.Domain.Services;

namespace RapidRetail.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? Authenticate(LoginRequestModel userLogin)
        {
            var authenticatedUser = _userRepository.GetUsers().FirstOrDefault(u =>
                u.Username.ToLower() == userLogin.Username.ToLower() && u.Password == userLogin.Password);

            return authenticatedUser;
        }
    }
}
