using Application.Helpers;
using Application.Models.Bmx;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RailRideBMX.Controllers;

public class BmxController : ApiController
{
    private readonly IBmxService _bmxService;

    public BmxController(IBmxService bmxService)
    {
        _bmxService = bmxService;
    }

    [HttpGet]
    [Authorize(Roles = "test")]
    public async Task<IActionResult> GetAllBmxAsync()
    {
        var test = await _bmxService.GetAllBmxAsync();
        return Ok(test);
    }
    
    [HttpGet]
    [Route("{guid}")]
    public async Task<IActionResult> GetBmxByIdAsync(Guid guid)
    {
        var test = await _bmxService.GetBmxByIdAsync(guid);
        return Ok(test);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateBmxAsync(BmxResponseModel bmxResponseModel)
    {
        var createBmx = await _bmxService.CreateBmxAsync(bmxResponseModel);
        return SuccessResponseHelper.CreatedResponse("Vous avez bien ajouté un article");
    }
    
    [HttpPut]
    [Route("{guid}")]
    public async Task<IActionResult> UpdateBmx(Guid guid, BmxResponseModel bmxResponseModel)
    {
        var updateBmx = await _bmxService.UpdateBmx(guid, bmxResponseModel);
        return Ok(updateBmx);
    }
    
    [HttpDelete]
    [Route("{guid}")]
    public async Task<IActionResult> DeleteBmx(Guid guid)
    {
        var deleteBmx = await _bmxService.DeleteBmx(guid);
        return Ok(deleteBmx);
    }
}