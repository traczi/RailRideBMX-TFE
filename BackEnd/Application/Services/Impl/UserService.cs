using Application.Models.User;
using Core.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace Application.Services.Impl;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;
    

    public UserService(IUserRepository userRepository, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<User> CreateUserAsync(UserResponseModel userResponseModel)
    {
        
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(userResponseModel.Password);
        var user = new User()
        {
            Firstname = userResponseModel.Firstname,
            Lastname = userResponseModel.Lastname,
            Email = userResponseModel.Email,
            Password = passwordHash, 
            Role = "user"
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
        var findUser = await _userRepository.FindByEmail(user); 
        if (findUser == null)
        {
            return "L'utilisateur n'a pas été trouvé";
        }
        bool passwordHash = BCrypt.Net.BCrypt.Verify(userLoginResponseModel.Password,findUser.Password);
        Console.WriteLine(userLoginResponseModel.Password);
        Console.WriteLine(findUser.Password);
        if (!passwordHash)
        {
            return "mdp mauvais";
        }
        var token = _jwtService.GenerateToken(findUser.Id, findUser.Email, findUser.Role);
        Console.WriteLine(token);
        var userLogin = await _userRepository.LoginUser(user);
        return userLogin;
    }
}   