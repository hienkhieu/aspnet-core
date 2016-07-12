using System;
using System.Collections.Generic;

namespace aspnet_core.models
{
    /// <summary>
    /// IModelCollection
    /// </summary>
    interface IModelCollection<T> where T : class
    {
        /// <summary>
        /// Find items
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> Find(Func<T, bool> predicate);

        /// <summary>
        /// add item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        void Add(T item);

        /// <summary>
        /// remove item
        /// </summary>
        /// <param name="item"></param>
        void Remove(T item);

    }

}
