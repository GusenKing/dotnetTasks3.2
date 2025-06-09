using Lesson13.Elasticsearch.Models;
using Lesson13.Elasticsearch.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lesson13.Elasticsearch.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SingleWordController(SingleWordService singleWordService) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> GetWordById(string id)
    {
        return await singleWordService.GetSingleWordById(id);
    }

    [HttpGet]
    public async Task<IResult> GetWordsBySearch(string searchWord)
    {
        return await singleWordService.SearchSingleWords(searchWord);
    }

    [HttpPost]
    public async Task<IResult> AddWord(string word)
    {
        return await singleWordService.AddWord(word);
    }

    [HttpPatch]
    public async Task<IResult> UpdateWord([FromBody] SingleWord singleWord)
    {
        return await singleWordService.UpdateWord(singleWord);
    }

    [HttpDelete]
    public async Task<IResult> DeleteWord(string id)
    {
        return await singleWordService.DeleteWordById(id);
    }

    [HttpGet]
    public async Task<IResult> GetTopWords()
    {
        return await singleWordService.GetAggregatedWords();
    }
}