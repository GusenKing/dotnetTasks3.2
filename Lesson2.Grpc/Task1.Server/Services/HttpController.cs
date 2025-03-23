using System.Net.Http.Headers;

namespace Task1.Server.Services;

public class HttpController
{
    public HttpController()
    {
        Client = new HttpClient();
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json")
        );
    }

    public HttpClient Client { get; }
}