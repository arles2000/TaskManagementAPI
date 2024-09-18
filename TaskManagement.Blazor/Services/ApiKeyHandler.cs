using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

public class ApiKeyHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {

        request.Headers.Add("X-API-Key", "123e4567-e89b-12d3-a456-426614174000");

        return await base.SendAsync(request, cancellationToken);
    }
}
