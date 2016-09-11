using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Models
{
    public class Movie
    {
        // fields
        private string title; 
        private decimal price; 
        private string imageUrl;

        // properties
        public string Title
        {
            get { return title; } // read
            set { title = value; } // write
        }

        public decimal Price 
        {
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Price is not accepted");
                }
                else {
                    price = value;
                }
            }
            get { return price; }
        }


        public string ImageUrl 
        {
            get { return imageUrl; }
            set { imageUrl = value; }
        }


        // constructors
        public Movie(string title, decimal price)
        {
            this.title = title;
            this.price = price;
        }

        public Movie(string title, decimal price, string imageUrl)
        {
            this.title = title;
            this.price = price;
            this.imageUrl = imageUrl;
        }
    }
}