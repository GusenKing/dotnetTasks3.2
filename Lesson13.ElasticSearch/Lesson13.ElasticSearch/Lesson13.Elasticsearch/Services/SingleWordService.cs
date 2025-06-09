using Elastic.Clients.Elasticsearch;
using Lesson13.Elasticsearch.Models;

namespace Lesson13.Elasticsearch.Services;

public class SingleWordService(IElasticsearchClientProvider provider)
{
    private const string IndexName = "lorem-words";
    private readonly ElasticsearchClient _client = provider.Client;

    public async Task TryCreateIndexAndAddWords(string wordsFilePath)
    {
        if ((await _client.Indices.ExistsAsync(IndexName)).Exists)
        {
            var countResp = await _client.CountAsync<SingleWord>(c => c.Indices(IndexName));
            if (countResp.Count > 0) return;
        }

        await _client.Indices.CreateAsync<SingleWord>(IndexName, c => c
            .Settings(s => s.NumberOfShards(1).NumberOfReplicas(0))
            .Mappings(m => m.Properties(p => { p.Keyword(x => x.Word); }
            ))
        );

        if (!File.Exists(wordsFilePath))
        {
            Console.WriteLine($"Файл {wordsFilePath} не найден.");
            return;
        }

        var text = await File.ReadAllTextAsync(wordsFilePath);
        var words = text
            .Replace(".", string.Empty)
            .Replace(",", string.Empty)
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select((w, i) => new SingleWord { Word = w.ToLowerInvariant() })
            .ToList();

        await _client.BulkAsync(b => b
            .Index(IndexName)
            .IndexMany(words));
    }

    public async Task<IResult> GetSingleWordById(string id)
    {
        var response = await _client.GetAsync<SingleWord>(id);
        if (!response.IsValidResponse) return Results.Problem(response.DebugInformation);

        var singleWord = response.Source;
        singleWord.Id = response.Id;
        return Results.Ok(singleWord);
    }

    public async Task<IResult> SearchSingleWords(string searchWord)
    {
        var response = await _client.SearchAsync<SingleWord>(s => s
            .From(0)
            .Size(10)
            .Query(q => q
                .Term(t => t
                    .Field(x => x.Word)
                    .Value(searchWord)
                )
            )
        );

        if (!response.IsValidResponse) return Results.Problem(response.DebugInformation);

        var words = response.Hits.Select(h =>
        {
            h.Source.Id = h.Id;
            return h.Source;
        }).ToList();
        return Results.Ok(words);
    }

    public async Task<IResult> AddWord(string word)
    {
        var response = await _client.IndexAsync(new SingleWord { Word = word });

        return response.IsValidResponse ? Results.Ok(response.Id) : Results.Problem(response.DebugInformation);
    }

    public async Task<IResult> UpdateWord(SingleWord singleWord)
    {
        var response =
            await _client.UpdateAsync<SingleWord, SingleWord>(IndexName, singleWord.Id, u => u.Doc(singleWord));

        return response.IsValidResponse ? Results.Ok() : Results.Problem(response.DebugInformation);
    }

    public async Task<IResult> DeleteWordById(string id)
    {
        var response = await _client.DeleteAsync(IndexName, id);

        return response.IsValidResponse ? Results.Ok() : Results.Problem(response.DebugInformation);
    }

    public async Task<IResult> GetAggregatedWords()
    {
        var response = await _client.SearchAsync<SingleWord>(search => search
            .Indices(IndexName)
            .Query(query => query
                .MatchAll()
            )
            .Aggregations(a => a.Add("top_words", t => t.Terms(d => d.Field("word")))).Size(5)
        );

        if (!response.IsValidResponse) return Results.Problem(response.DebugInformation);

        var words = response.Hits.Select(h =>
        {
            h.Source.Id = h.Id;
            return h.Source;
        }).ToList();
        return Results.Ok(words);
    }
}