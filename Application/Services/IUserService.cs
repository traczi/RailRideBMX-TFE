using Application.Models.User;
using Core.Entities;

namespace Application.Services;

public interface IUserService
{
    Task<User> CreateUserAsync(UserResponseModel userResponseModel);
}