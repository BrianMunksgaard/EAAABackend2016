using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Infrastructure
{
    /// <summary>
    /// The repository class is used as a data storage controller.
    /// With the repository class, we can retrieve the various data
    /// (that is normally stored in a database) that the appliaction
    /// needs.
    /// </summary>
    public class Repository
    {
        public List<Product> Products = new List<Product>();
        //public List<Invoice> Invoices = new List<Invoice>();

        /// <summary>
        /// Returns all books in the repository.
        /// </summary>
        public List<Book> Books
        {
            get
            {
                return Products.OfType<Book>().ToList();
            }
        }
        
        /// <summary>
        /// Return all CDs in the repository.
        /// </summary>
        public List<MusicCD> MusicCDs
        {
            get
            {
                return Products.OfType<MusicCD>().ToList();
            }
        }

        /// <summary>
        /// Return all movies in the repository.
        /// </summary>
        public List<Movie> Movies
        {
            get
            {
                return Products.OfType<Movie>().ToList();
            }
        }



        /// <summary>
        /// Initialize the repository.
        /// </summary>
        public Repository()
        {
            Products.AddRange(ProductData.GetBooks());
            Products.AddRange(ProductData.GetMusicCDs());
            Products.AddRange(ProductData.GetMovies());
        }
    }
}