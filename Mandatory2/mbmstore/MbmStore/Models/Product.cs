using MbmStore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Models
{
    /// <summary>
    /// Base product class with properties common
    /// for all products.
    /// </summary>
    public class Product
    {
        #region PrivateFields

        private int productId;
        private string title;
        private string imageUrl;
        private decimal price;
        private string category;

        #endregion

        #region Properties

        /// <summary>
        /// Unique product id.
        /// </summary>
        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        /// <summary>
        /// The product title.
        /// </summary>
        public string Title
        {
            get { return title == null ? string.Empty: title; }
            set { title = value; }
        }

        /// <summary>
        /// URL to the product image.
        /// </summary>
        public string ImageUrl
        {
            get { return imageUrl == null ? string.Empty : imageUrl; }
            set { imageUrl = value; }
        }

        /// <summary>
        /// The product price.
        /// </summary>
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        /// <summary>
        /// Product category.
        /// </summary>
        public string Category
        {
            get { return category == null ? category = string.Empty : category; }
            set { category = value; }
        }

        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Product() { }

        /// <summary>
        /// Initialization constructor.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="price"></param>
        public Product(string title, decimal price)
        {
            this.title = title;
            this.price = price;
            this.productId = NumberUtil.Instance.UniqueNumber;
        }
    }
}