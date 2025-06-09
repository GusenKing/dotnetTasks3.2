using Elastic.Clients.Elasticsearch;

namespace Lesson13.Elasticsearch.Services;

public interface IElasticsearchClientProvider
{
    ElasticsearchClient Client { get; }
}