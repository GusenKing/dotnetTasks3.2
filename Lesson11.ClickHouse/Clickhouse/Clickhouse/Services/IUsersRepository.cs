using Clickhouse.Models;

namespace Clickhouse.Services;

public interface IUsersRepository
{
    public Task<int> InsertAsync(User user);
    public Task DeleteByIdAsync(uint id);
    public Task<List<User>> GetAllAsync();
    public Task<List<User>> SearchByNameAsync(string name);

    public Task<List<User>> SearchByNameAndOrAgeAsync(
        string name,
        ushort age,
        bool useAnd = true);
}