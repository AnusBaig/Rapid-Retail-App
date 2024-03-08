using RapidRetail.Domain.Entities;
using RapidRetail.Domain.Repositories;

namespace RapidRetail.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public List<User> GetUsers()
        {
            var users = new List<User>
            {
                new() { Id = 1, Username="Israr",Password="12345",Role="Admin"},
                new() { Id = 2, Username="Anus",Password="12345",Role="User"},
                new() { Id = 3, Username="Demo",Password="12345",Role="User"}
            };

            return users;
        }
    }
}
