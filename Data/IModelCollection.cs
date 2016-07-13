using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnet_core.models
{
    /// <summary>
    /// IModelCollection
    /// </summary>
    public interface IModelCollection<T> where T : class
    {
        /// <summary>
        /// Find items
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> Find(Func<T, bool> predicate);

        /// <summary>
        /// Get All 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAll();

        /// <summary>   
        /// add item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task Add(T item);

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task Update(T item);

        /// <summary>
        /// remove item
        /// </summary>
        /// <param name="item"></param>
        Task Remove(T item);

    }

}
