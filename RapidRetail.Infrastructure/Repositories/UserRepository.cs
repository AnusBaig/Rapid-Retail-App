using RapidRetail.Domain.Entities;
using RapidRetail.Domain.Repositories;

namespace RapidRetail.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public List<User> GetUsers()
        {
            List<User> users = new()
            {
                new User { Id = 1, Username="Israr",Password="12345",Role="Admin"},
                new User { Id = 2, Username="Anus",Password="12345",Role="User"},
                new User { Id = 3, Username="Demo",Password="12345",Role="User"}
            };

            return users;
        }
    }
}
