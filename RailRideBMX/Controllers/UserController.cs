using Application.Models.User;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace RailRideBMX.Controllers;

public class UserController : ApiController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync(UserResponseModel userResponseModel)
    {
        var createUser = await _userService.CreateUserAsync(userResponseModel);
        return Ok(createUser);
    }
}