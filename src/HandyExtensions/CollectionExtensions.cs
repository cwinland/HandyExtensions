using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HandyExtensions
{
    /// <summary>
    /// Extension methods for collections.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Sets the <paramref name="collection" /> instance to the <paramref name="newItems" /> provided.
        /// </summary>
        /// <typeparam name="TItem">Type of the item stored in the collection.</typeparam>
        /// <param name="collection">The <see cref="ObservableCollection{T}" /> to be updated</param>
        /// <param name="newItems">The items to set the collection to.</param>
        public static ObservableCollection<TItem>? SetItems<TItem>(this ObservableCollection<TItem>? collection, IEnumerable<TItem>? newItems)
        {
            if (collection == null)
            {
                return collection;
            }

            collection.Clear();

            if (newItems == null)
            {
                return collection;
            }

            newItems.ToList().ForEach(collection.Add);

            return collection;
        }
    }
}