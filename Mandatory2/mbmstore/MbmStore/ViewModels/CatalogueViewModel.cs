using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.ViewModels
{
    public class CatalogueViewModel
    {

        private List<Product> products;

        public List<Product> Products
        {
            get
            {
                if(products == null)
                {
                    products = new List<Product>();
                }
                return products;
            }
        }

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

        public CatalogueViewModel(List<Product> products)
        {
            this.products = products;
        }
    }
}