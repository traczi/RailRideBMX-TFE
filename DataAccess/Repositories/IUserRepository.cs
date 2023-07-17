using Core.Entities;

namespace DataAccess.Repositories;

public interface IUserRepository
{
    Task<User> CreateUser(User user);
}