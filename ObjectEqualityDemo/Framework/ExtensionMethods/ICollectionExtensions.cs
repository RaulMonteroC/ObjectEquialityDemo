using System;
using System.Collections.Generic;

namespace ObjectEqualityDemo.Framework.ExtensionMethods
{
    public static class ICollectionExtensions
    {
        /// <summary>
        /// Check if supplied collection is equivalent to the current one
        /// </summary>
        /// <returns><c>true</c>, if contains the same items in the same order, <c>false</c> otherwise.</returns>
        /// <param name="currentCollection">Current Collection Instance</param>
        /// <param name="collectionToTest">Collection to be tested against the current instance</param>
        /// <typeparam name="T">The collection's item type</typeparam>
        public static bool IsEqual<T>(this ICollection<T> currentCollection, ICollection<T> collectionToTest)
        {
            if ((currentCollection != null) && (collectionToTest != null))
            {
                // both object have number of elements
                if (currentCollection.Count != collectionToTest.Count) return false;

                // If same number of elements, compare their value
                foreach (var item in collectionToTest)
                {
                    if (!currentCollection.Contains(item)) return false; ;
                }
            }
            else if ((currentCollection != null) || (collectionToTest != null))
            {
                // one, but not both, have null wavelengths... not equal
                return false;
            }

            return true;
        }

        public static ICollection<T> Clone<T>(this ICollection<T> currentCollection) where T : IClonable<T>
        {
            var clonedCollection = new List<T>();

            foreach (var item in currentCollection)
            {
                clonedCollection.Add(item.Clone());
            }

            return clonedCollection;
        }
    }
}
