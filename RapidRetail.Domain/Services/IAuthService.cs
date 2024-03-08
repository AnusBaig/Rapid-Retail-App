using RapidRetail.Domain.Aggregates;
using RapidRetail.Domain.Entities;

namespace RapidRetail.Domain.Services
{
    public interface IAuthService
    {
        User? Authenticate(LoginRequestModel userLogin);
    }
}
