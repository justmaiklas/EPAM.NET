using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTask.Models;
using WebApiTask.Services;

namespace WebApiTask.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
//[Authorize]
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
        var player = _playerService.GetPlayerById(id);
        if (player == null) {
            return NotFound();
        }
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
            Position = position
        };
        player = _playerService.CreatePlayer(player);
        if (player == null) {
            return BadRequest();
        }
        return Created("/api/player/getById/" + player.Id, player);
    }
    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, string name, int age, string position)
    {
        var player = _playerService.GetPlayerById(id);
        if (player == null)
        {
            return NotFound();
        }
        if (player.Name == name && player.Age == age && player.Position == position) {
            return NoContent();
        }
        var updatedPlayer = _playerService.UpdatePlayer(id, name, age, position);
        return Ok(updatedPlayer);
        
    }
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var player = _playerService.DeletePlayer(id);
        if (player == null)
        {
            return NotFound();
        }
        return NoContent();
    }

}