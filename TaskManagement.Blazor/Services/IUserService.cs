using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

public interface IUserService
{
    Task<List<Usuario>> GetAllUsersAsync();
    Task CreateUserAsync(Usuario user);
    Task DeleteUserAsync(int userId);
}
