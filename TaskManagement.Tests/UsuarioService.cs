using Moq;
using TaskManagement.Repository.Interfaces;
using TaskManagement.Services.Services;
using Xunit;

public class UsuarioServiceTests
{
    private readonly UsuarioService _usuarioService;
    private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;

    public UsuarioServiceTests()
    {
        // Crea un mock del repositorio de usuarios
        _usuarioRepositoryMock = new Mock<IUsuarioRepository>();

        // Inyecta el mock en el servicio de usuario
        _usuarioService = new UsuarioService(_usuarioRepositoryMock.Object);
    }

    [Fact]
    public async Task GetAllUsuariosAsync_ShouldReturnListOfUsuarios()
    {
        // Arrange
        var usuarios = new List<Usuario>
    {
        new Usuario { Id = 1, Nombre = "Juan", Apellido = "Pérez", Correo = "juan.perez@example.com", Telefono = "123456789" }
    };

        _usuarioRepositoryMock.Setup(repo => repo.GetAllUsuariosAsync()).ReturnsAsync(usuarios);

        // Act
        var result = await _usuarioService.GetAllUsuariosAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("Juan", result.First().Nombre);
        Assert.Equal("Pérez", result.First().Apellido);
        Assert.Equal("juan.perez@example.com", result.First().Correo);
        Assert.Equal("123456789", result.First().Telefono);
    }


}
