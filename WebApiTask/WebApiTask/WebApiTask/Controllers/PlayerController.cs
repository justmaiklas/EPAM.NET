using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTask.Models;
using WebApiTask.Services;

namespace WebApiTask.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _playerService;
    public PlayerController(IPlayerService playerService)
    {
        _playerService = playerService;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_playerService.GetAllPlayers());
    }
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(_playerService.GetPlayerById(id));
    }
    [HttpPost]
    public IActionResult Create(string name, int age, string position)
    {
        var player = new Player
        {
            Id = Guid.NewGuid(),
            Name = name,
            Age = age,
            Position = position}
        };
        _playerService.CreatePlayer(player);
        return Ok(player);
    }
    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, string name, int age, string position)
    {
        var player = _playerService.GetPlayerById(id);
        if (player == null)
        {
            return NotFound();
        }
        player.Name = name;
        player.Age = age;
        player.Position = position;
        _playerService.UpdatePlayer(player);
        return Ok(player);
        
    }
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        return Ok(_playerService.DeletePlayer(id));
    }

}