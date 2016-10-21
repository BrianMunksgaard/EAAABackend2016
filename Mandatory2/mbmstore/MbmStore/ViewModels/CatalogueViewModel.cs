using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MbmStore.ViewModels
{
    /// <summary>
    /// View model for the product catalogue.
    /// </summary>
    public class CatalogueViewModel
    {
        #region PrivateFields

        private List<Product> products;
        private SelectList quantitySelectList;

        #endregion

        /// <summary>
        /// SelectList to be used for quantity dropdowns
        /// in the view.
        /// </summary>
        public SelectList QuantitySelectList
        {
            get
            {
                if(quantitySelectList == null)
                {
                    quantitySelectList = new SelectList(Enumerable.Range(1, 20));
                }
                return quantitySelectList;
            }
        }

        /// <summary>
        /// Return all products.
        /// </summary>
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

        /// <summary>
        /// View model constructor.
        /// </summary>
        /// <param name="products"></param>
        public CatalogueViewModel(List<Product> products)
        {
            this.products = products;
        }
    }
}