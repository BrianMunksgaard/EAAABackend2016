using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Models
{
    /// <summary>
    /// This class is used to hold information about a book
    /// in the store.
    /// </summary>
    public class Book : Product
    {
        #region PrivateFields

        private string author;
        private short published;
        private string publisher;
        private string isbn;

        #endregion

        #region Properties

        /// <summary>
        /// The author of the book.
        /// </summary>
        public string Author
        {
            get { return author == null ? string.Empty : author; }
            set { author = value; }
        }

        /// <summary>
        /// The year the book was published.
        /// </summary>
        public short Published
        {
            get { return published; }
            set { published = value; }
        }

        /// <summary>
        /// Book publisher.
        /// </summary>
        public string Publisher
        {
            get { return publisher == null ? string.Empty : publisher; }
            set { publisher = value; }
        }

        /// <summary>
        /// International standard book number.
        /// </summary>
        public string ISBN
        {
            get { return isbn; }
            set { isbn = value; }
        }

        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Book() { }

        /// <summary>
        /// Initialization constructor.
        /// </summary>
        /// <param name="author"></param>
        /// <param name="title"></param>
        /// <param name="price"></param>
        /// <param name="published"></param>
        public Book(string author, string title, decimal price, short published) : base(title, price)
        {
            this.author = author;
            this.published = published;
        }
    }
}