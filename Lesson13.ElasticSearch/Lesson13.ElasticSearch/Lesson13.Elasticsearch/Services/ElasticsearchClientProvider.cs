using Elastic.Clients.Elasticsearch;

namespace Lesson13.Elasticsearch.Services;

public class ElasticsearchClientProvider : IElasticsearchClientProvider
{
    public ElasticsearchClient Client { get; }

    public ElasticsearchClientProvider(IConfiguration configuration)
    {
        var settings = new ElasticsearchClientSettings(new Uri(configuration["Elastic:Uri"]!))
            .DefaultIndex("lorem-words");
        Client = new ElasticsearchClient(settings);
    }
}