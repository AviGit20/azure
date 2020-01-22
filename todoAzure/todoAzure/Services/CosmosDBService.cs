

namespace todoAzure.Services
{
    using Microsoft.Azure.Cosmos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using todoAzure.Models;

    public class CosmosDBService : ICosmosDbService
    {
        private Container _container;

        public CosmosDBService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }
        public async Task AddItemAsync(Items item)
        {
            await this._container.CreateItemAsync<Items>(item, new PartitionKey(item.Id));
        }

        public async Task DeleteItemAsync(string id)
        {
            await this._container.DeleteItemAsync<Items>(id, new PartitionKey(id));
        }

        public async Task<Items> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<Items> response = await this._container.ReadItemAsync<Items>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch(CosmosException ce)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Items>> GetItemsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<Items>(new QueryDefinition(queryString));
            List<Items> results = new List<Items>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateItemAsync(string id, Items item)
        {
            await this._container.UpsertItemAsync<Items>(item, new PartitionKey(id));
        }
    }
}
