using Microsoft.AspNetCore.Mvc;
using TheEasyBazar.API.Models;
using TheEasyBazar.Service.DTOs.Users;
using TheEasyBazar.Service.Interfaces;

namespace TheEasyBazar.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
        this._userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await this._userService.RetriveAllAsync()
        });

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await this._userService.RetriveByIdAsync(id)
        });

    [HttpPost]
    public async Task<IActionResult> PostAsync(UserForCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await this._userService.CreateAsync(dto)
        });

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await this._userService.RemoveAsync(id)
        });

    [HttpPut]
    public async Task<IActionResult> PutAsync(UserForUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await this._userService.UpdateAsync(dto)
        });
}
