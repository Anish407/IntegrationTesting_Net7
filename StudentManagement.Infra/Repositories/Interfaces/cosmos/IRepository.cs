using Microsoft.Azure.Cosmos;
using StudentManagement.Core.Entities;

namespace StudentManagement.Infra.Interfaces.cosmos
{
    public interface IRepository<TItem>
           where TItem :  IDocument
    {
        ValueTask<TItem> GetItem(string id, string partitionKeyValue = "", CancellationToken cancellationToken = default);

        ValueTask<TItem> GetItem(string id, PartitionKey partitionKey, CancellationToken cancellationToken = default);

        ValueTask<IEnumerable<TItem>> GetBySQLQuery(string query, CancellationToken cancellationToken = default);

        ValueTask<TItem> Create(TItem value, CancellationToken cancellationToken = default);

        ValueTask<TItem> Update(TItem value, CancellationToken cancellationToken = default);

        ValueTask<bool> Delete(string id, PartitionKey partitionKey = default, CancellationToken cancellationToken = default);

        Task<TransactionalBatchResponse> ExecuteTransaction(TransactionalBatch batch);

        IQueryable<TItem> GetQueryable();

        Task<IEnumerable<TItem>> ExecuteQueryabe(IQueryable<TItem> queryableEntity);
    }
}
