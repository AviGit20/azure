namespace todoAzure.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using todoAzure.Models;

    public interface ICosmosDbService
    {
        Task<IEnumerable<Items>> GetItemsAsync(string query);
        Task<Items> GetItemAsync(string id);
        Task AddItemAsync(Items item);
        Task UpdateItemAsync(string id, Items item);
        Task DeleteItemAsync(string id);
    }
}
