using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MbmStore.DAL
{
    /// <summary>
    /// Generic repository interface that specifies CRUD like methods.
    /// Implemening classes may implement additional repository operations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Retrieve all items of type T.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetItems();

        /// <summary>
        /// Retrieve the item of type T identified by the id parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetItem(int id);

        /// <summary>
        /// Save the specified type T.
        /// </summary>
        /// <param name="product"></param>
        void SaveItem(T t);

        /// <summary>
        /// Retrieve, delete and return the item of type T identified
        /// by the id parameter.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T DeleteItem(int id);
    }
}
