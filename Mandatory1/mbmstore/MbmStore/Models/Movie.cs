using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Models
{
    /// <summary>
    /// This class is used to hold information
    /// about a movie in the store.
    /// </summary>
    public class Movie : Product
    {
        #region PrivateFields

        private string director;

        #endregion

        #region Properties

        public string Director
        {
            get { return director; }
            set { director = value; }
        }

        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Movie() { }

        /// <summary>
        /// Initilization constructor.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="price"></param>
        /// <param name="director"></param>
        public Movie(string title, decimal price, string director) : base(title, price)
        {
            this.director = director;
        }

    }
}