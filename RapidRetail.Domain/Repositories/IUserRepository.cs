using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RapidRetail.Domain.Entities;

namespace RapidRetail.Domain.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
    }
}
