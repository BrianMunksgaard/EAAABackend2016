using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.ViewModels
{
    public class ProductsListViewModel
    {
        /// <summary>
        /// Returns all books in products list.
        /// </summary>
        public List<Book> Books
        {
            get
            {
                return Products.OfType<Book>().ToList();
            }
        }

        /// <summary>
        /// Return all CDs in products list.
        /// </summary>
        public List<MusicCD> MusicCDs
        {
            get
            {
                return Products.OfType<MusicCD>().ToList();
            }
        }

        /// <summary>
        /// Return all movies in products list.
        /// </summary>
        public List<Movie> Movies
        {
            get
            {
                return Products.OfType<Movie>().ToList();
            }
        }

        /// <summary>
        /// All current products on the page.
        /// </summary>
        public IEnumerable<Product> Products { get; set; }

        /// <summary>
        /// Page information.
        /// </summary>
        public PagingInfo PagingInfo { get; set; }

        /// <summary>
        /// The currently selected product category.
        /// </summary>
        public string CurrentCategory { get; set; }
    }
}