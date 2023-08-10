using Application.Models.User;
using Core.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using OneOf;

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
            Firstname = userResponseModel.Name,
            Lastname = userResponseModel.Surname,
            Email = userResponseModel.Email,
            Password = userResponseModel.Password
        };
        await _userRepository.CreateUser(user);
        return user;
    }

    public async Task<OneOf<User, string>> LoginUserAsync(UserLoginResponseModel userLoginResponseModel)
    {
        var user = new User()
        {
            Email = userLoginResponseModel.Email,
            Password = userLoginResponseModel.Password
        };
        var userLogin = await _userRepository.LoginUser(user);
        if (userLogin == null)
        {
            return "L'utilisateur n'a pas été trouvé";
        }
        return userLogin;
    }
}