using Moq;
using TaskManagement.Services.Services;
using TaskManagement.Repository.Interfaces;
using TaskManagement.Domain.Entities;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TareaServiceTests
{
    private readonly TareaService _tareaService;
    private readonly Mock<ITareaRepository> _tareaRepositoryMock;

    public TareaServiceTests()
    {
        // Crea un mock del repositorio de tareas
        _tareaRepositoryMock = new Mock<ITareaRepository>();

        // Inyecta el mock en el servicio de tareas
        _tareaService = new TareaService(_tareaRepositoryMock.Object);
    }

    [Fact]
    public async Task GetAllTareasAsync_ShouldReturnListOfTareas()
    {
        // Arrange
        var tareas = new List<Tarea>
    {
        new Tarea { Id = 1, Titulo = "Completar informe", Descripcion = "Preparar y completar el informe del proyecto", Finalizado = false }
    };

        _tareaRepositoryMock.Setup(repo => repo.GetAllTareasAsync()).ReturnsAsync(tareas);

        // Act
        var result = await _tareaService.GetAllTareasAsync();

        // Convertir el resultado a una lista para acceder a los elementos por índice
        var resultList = result.ToList();

        // Assert
        Assert.NotNull(resultList);
        Assert.Single(resultList);
        Assert.Equal("Completar informe", resultList[0].Titulo);
    }


    [Fact]
    public async Task GetTareaByIdAsync_ShouldReturnTarea_WhenTareaExists()
    {
        // Arrange
        var tareaId = 1;
        var tarea = new Tarea { Id = tareaId, Titulo = "Completar informe" };

        _tareaRepositoryMock.Setup(repo => repo.GetTareaByIdAsync(tareaId)).ReturnsAsync(tarea);

        // Act
        var result = await _tareaService.GetTareaByIdAsync(tareaId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(tareaId, result.Id);
        Assert.Equal("Completar informe", result.Titulo);
    }

    [Fact]
    public async Task GetTareaByIdAsync_ShouldReturnNull_WhenTareaDoesNotExist()
    {
        // Arrange
        var tareaId = 1;
        _tareaRepositoryMock.Setup(repo => repo.GetTareaByIdAsync(tareaId)).ReturnsAsync((Tarea)null);

        // Act
        var result = await _tareaService.GetTareaByIdAsync(tareaId);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task CreateTareaAsync_ShouldReturnCreatedTarea()
    {
        // Arrange
        var tarea = new Tarea { Id = 1, Titulo = "Completar informe" };

        _tareaRepositoryMock.Setup(repo => repo.CreateTareaAsync(tarea)).ReturnsAsync(tarea);

        // Act
        var result = await _tareaService.CreateTareaAsync(tarea);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(tarea.Id, result.Id);
        Assert.Equal(tarea.Titulo, result.Titulo);
    }

    [Fact]
    public async Task UpdateTareaAsync_ShouldReturnUpdatedTarea()
    {
        // Arrange
        var tarea = new Tarea { Id = 1, Titulo = "Actualizar informe" };

        _tareaRepositoryMock.Setup(repo => repo.UpdateTareaAsync(tarea)).ReturnsAsync(tarea);

        // Act
        var result = await _tareaService.UpdateTareaAsync(tarea);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(tarea.Id, result.Id);
        Assert.Equal("Actualizar informe", result.Titulo);
    }

    [Fact]
    public async Task DeleteTareaAsync_ShouldCallDeleteOnce_WhenTareaExists()
    {
        // Arrange
        var tareaId = 1;

        _tareaRepositoryMock.Setup(repo => repo.DeleteTareaAsync(tareaId)).Returns(Task.CompletedTask);

        // Act
        await _tareaService.DeleteTareaAsync(tareaId);

        // Assert
        _tareaRepositoryMock.Verify(repo => repo.DeleteTareaAsync(tareaId), Times.Once);
    }
}
