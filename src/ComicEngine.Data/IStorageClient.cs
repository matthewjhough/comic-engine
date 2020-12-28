using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComicEngine.Data
{
    /// <summary>
    /// Common Create, Read, Update, Delete operations to perform on a type of resource.
    /// </summary>
    /// <typeparam name="T">The Type of the Resource.</typeparam>
    public interface IStorageClient<T>
    {
        /// <summary>
        /// Adds a new Resource to specified database.
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="subject"></param>
        Task<T> Create(T resource, string subject);

        /// <summary>
        /// Gets all the resources from specified userid.
        /// </summary>
        /// <param name="subject"></param>
        Task<IEnumerable<T>> Get(string subject);
        
        /// <summary>
        /// Deletes resource by Id from data-source.
        /// </summary>
        /// <param name="resourceId"></param>
        Task<bool> Delete(string resourceId);

        /// <summary>
        /// Updates the persisted resource with the new data.
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="resource"></param>
        Task<T> Update(string resourceId, T resource);
    }
}