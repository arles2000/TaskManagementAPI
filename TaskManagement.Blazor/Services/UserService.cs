using System.Net.Http.Json;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateUserAsync(Usuario user)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Usuario", user);
        response.EnsureSuccessStatusCode();
    }

    public async Task<List<Usuario>> GetAllUsersAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Usuario>>("api/Usuario");
    }

    public async Task DeleteUserAsync(int userId)
    {
        var response = await _httpClient.DeleteAsync($"api/Usuario/{userId}");
        response.EnsureSuccessStatusCode();
    }
}
