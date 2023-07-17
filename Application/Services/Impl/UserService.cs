using Application.Models.Bmx;
using Application.Models.User;
using Core.Entities;
using DataAccess.Repositories;

namespace Application.Services.Impl;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateUserAsync(UserResponseModel userResponseModel)
    {
        var user = new User()
        {
            Name = userResponseModel.Name,
            Surname = userResponseModel.Surname,
            Email = userResponseModel.Email,
            Password = userResponseModel.Password
        };
        await _userRepository.CreateUser(user);
        return user;
    }
}