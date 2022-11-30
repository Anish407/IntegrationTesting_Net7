using Microsoft.Azure.Cosmos;
using StudentManagement.Infra.Common.Exceptions;

namespace StudentManagement.Infra.Common.Helpers
{
    public class TryCatchWrapper
    {
        public async Task<T> TryCatch<T>(Func<Task<T>> function)
        {
            try
            {
                return await function();
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return default;
            }
            catch (CosmosException ex)
            {
                throw new DatabaseException($"Database Cosmos Exception: {ex.Message}", details: ex.ToString());
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"Database Exception: {ex.Message}", $"Stacktrace:{ex.StackTrace}, InnerException: {ex.InnerException}");
            }
        }

        public T TryCatch<T>(Func<T> function, string details = "")
        {
            try
            {
                return function();
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return default;
            }
            catch (CosmosException ex)
            {
                throw new DatabaseException($"Database Cosmos Exception: {ex.Message}", details: ex.ToString());
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"Database Exception: {ex.Message}", $"Stacktrace:{ex.StackTrace}, InnerException: {ex.InnerException}");
            }
        }
    }
}
