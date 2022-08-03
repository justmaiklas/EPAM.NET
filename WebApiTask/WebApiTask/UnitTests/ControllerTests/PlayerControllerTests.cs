using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using WebApiTask.Controllers;
using WebApiTask.Models;
using WebApiTask.Services;

namespace UnitTests.ControllerTests;

public class PlayerControllerTests
{
    private Mock<IPlayerService> _playerServiceMock;
    public PlayerControllerTests()
    {
        _playerServiceMock = new Mock<IPlayerService>();
    }

    [Fact]
    public void GetAllReturnsAllPlayers()
    {
        // Arrange
        _playerServiceMock.Setup(x => x.GetAllPlayers()).Returns(GetTestPlayers());

        //Act
        var controller = new PlayerController(_playerServiceMock.Object);
        var result = controller.GetAll();
        var okResult = result as OkObjectResult;

        //Assert
        Assert.NotNull(okResult);
        Assert.True(okResult is OkObjectResult);
        Assert.IsType<List<Player>>(okResult?.Value);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        Assert.Equal(2, ((List<Player>)okResult.Value).Count);
    }

    [Fact]
    public void GetByIdReturnsPlayer()
    {
        _playerServiceMock.Setup(x => x.GetPlayerById(It.IsAny<Guid>())).Returns(GetTestPlayer());
        var controller = new PlayerController(_playerServiceMock.Object);
        var result = controller.GetById(Guid.NewGuid());
        var okResult = result as OkObjectResult;
        Assert.NotNull(okResult);
        Assert.True(okResult is OkObjectResult);
        Assert.IsType<Player>(okResult?.Value);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
    }
    [Fact]
    public void GetByIdReturnsNotFound()
    {
        _playerServiceMock.Setup(x => x.GetPlayerById(It.IsAny<Guid>())).Returns((Player)null);
        var controller = new PlayerController(_playerServiceMock.Object);
        var result = controller.GetById(Guid.NewGuid());
        var notFoundResult = result as NotFoundResult;
        Assert.NotNull(notFoundResult);
        Assert.True(notFoundResult is NotFoundResult);
        Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
    }
    [Fact]
    public void CreatePlayerReturnsCreated()
    {
        _playerServiceMock.Setup(x => x.CreatePlayer(It.IsAny<Player>())).Returns(GetTestPlayer());
        var controller = new PlayerController(_playerServiceMock.Object);
        var player = GetTestPlayer();
        var result = controller.Create(player.Name, player.Age, player.Position);
        var createdResult = result as CreatedResult;
        Assert.NotNull(createdResult);
        Assert.True(createdResult is CreatedResult);
        Assert.Equal(StatusCodes.Status201Created, createdResult.StatusCode);
    }
    [Fact]
    public void CreatePlayerReturnsBadRequest()
    {
        _playerServiceMock.Setup(x => x.CreatePlayer(It.IsAny<Player>())).Returns((Player)null);
        var controller = new PlayerController(_playerServiceMock.Object);
        var player = GetTestPlayer();
        var result = controller.Create(player.Name, player.Age, player.Position);
        var badRequestResult = result as BadRequestResult;
        Assert.NotNull(badRequestResult);
        Assert.True(badRequestResult is BadRequestResult);
        Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
    }
    [Fact]
    public void UpdatePlayerReturnsOk()
    {
        _playerServiceMock.Setup(x => x.GetPlayerById(It.IsAny<Guid>())).Returns(new Player());
        _playerServiceMock.Setup(x => x.UpdatePlayer(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>())).Returns(GetTestPlayer());
        var controller = new PlayerController(_playerServiceMock.Object);
        var player = GetTestPlayer();
        var result = controller.Update(player.Id, player.Name, player.Age, player.Position);
        var okResult = result as OkObjectResult;
        Assert.NotNull(okResult);
        Assert.True(okResult is OkObjectResult);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
    }
    [Fact]
    public void UpdatePlayerReturnsNoContent()
    {
        _playerServiceMock.Setup(x => x.GetPlayerById(It.IsAny<Guid>())).Returns(GetTestPlayer());
        _playerServiceMock.Setup(x => x.UpdatePlayer(It.IsAny<Guid>(), It.IsAny<string>(),It.IsAny<int>(),It.IsAny<string>())).Returns(GetTestPlayer());
        var controller = new PlayerController(_playerServiceMock.Object);
        var player = GetTestPlayer();
        var result = controller.Update(player.Id, player.Name, player.Age, player.Position);
        var noContentResult = result as NoContentResult;
        Assert.NotNull(noContentResult);
        Assert.True(noContentResult is NoContentResult);
        Assert.Equal(StatusCodes.Status204NoContent, noContentResult.StatusCode);
    }
    [Fact]
    public void UpdatePlayerReturnsNotFound()
    {
        _playerServiceMock.Setup(x => x.UpdatePlayer(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>())).Returns((Player)null);
        var controller = new PlayerController(_playerServiceMock.Object);
        var player = GetTestPlayer();
        var result = controller.Update(player.Id, player.Name, player.Age, player.Position);
        var notFoundResult = result as NotFoundResult;
        Assert.NotNull(notFoundResult);
        Assert.True(notFoundResult is NotFoundResult);
        Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
    }
    [Fact]
    public void DeletePlayerReturnsNoContent()
    {
        _playerServiceMock.Setup(x => x.DeletePlayer(It.IsAny<Guid>())).Returns(GetTestPlayer());
        var controller = new PlayerController(_playerServiceMock.Object);
        var result = controller.Delete(Guid.NewGuid());
        var noContentResult = result as NoContentResult;
        Assert.NotNull(noContentResult);
        Assert.True(noContentResult is NoContentResult);
        Assert.Equal(StatusCodes.Status204NoContent, noContentResult.StatusCode);
    }
    [Fact]
    public void DeletePlayerReturnsNotFound()
    {
        _playerServiceMock.Setup(x => x.DeletePlayer(It.IsAny<Guid>())).Returns((Player)null);
        var controller = new PlayerController(_playerServiceMock.Object);
        var result = controller.Delete(Guid.NewGuid());
        var notFoundResult = result as NotFoundResult;
        Assert.NotNull(notFoundResult);
        Assert.True(notFoundResult is NotFoundResult);
        Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
    }
    
    public static List<Player> GetTestPlayers()
    {
        return new List<Player>
        {
            new Player { Id = Guid.Parse("c639d72e-6cea-46b9-b36a-1afeb18c7851"), Name = "Player 1" },
            new Player { Id = Guid.Parse("caa1a368-ad89-4912-9e12-a29e661ee666"), Name = "Player 2" },
                    
        };
    }
    public static Player GetTestPlayer()
    {
        return new Player
        {
             Id = Guid.Parse("c639d72e-6cea-46b9-b36a-1afeb18c7851"), Name = "Player 1"

        };
    }
    public static List<Team> GetTestTeams()
    {
        return new List<Team>
        {
            new Team { Id = Guid.Parse("2278bc95-040c-4be1-af49-1c70b7a542b2"), Name = "Team 1" },
            new Team { Id = Guid.Parse("ef331a61-2c78-46ea-b884-93205dc5eb08"), Name = "Team 2" },

        };
    }
}