using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Infrastructure
{
    /// <summary>
    /// This class is used to simulate some kind of data storage
    /// so it is possible to hide the ugly object creation and
    /// initializtion.
    /// </summary>
    public class ProductData
    {
        #region Private Fields

        /// <summary>
        /// Randomizer.
        /// </summary>
        private static Random r = new Random();

        #endregion

        /// <summary>
        /// Return books.
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetBooks()
        {
            string category = "Book";
            List<Product> p = new List<Product>();
            p.Add(new Book("Adam Freeman", "Pro ASP.NET MVC 5", 44.99m, 2013) { ImageUrl = "proaspmvc5.jpg", Publisher = "apress", Category = category });
            p.Add(new Book("Kristina Chodorow", "MongoDB: The Definitive Guide", 26.61m, 2013) { ImageUrl = "mongodb.jpg", Publisher = "O'Reilly'", Category = category });
            return p;
        }

        /// <summary>
        /// Return CDs.
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetMusicCDs()
        {
            string category = "MusicCD";
            List<Product> p = new List<Product>();
            {
                MusicCD cd = new MusicCD("Metallica", "And Justice for All", 5.0m, 1988)
                {
                    Label = "Elektra Records",
                    ImageUrl = "andjusticeforall.jpg",
                    Category = category
                };
                cd.AddTrack("Blackend", "6:40", "Hetfield, Lars Ulrich, Jason Newsted");
                cd.AddTrack("And Justice For All", "9:44", "Hetfield, Ulrich, Kirk Hammett");
                cd.AddTrack("Eye Of The Beholder", "6:25", "Hetfield, Ulrich, Hammett");
                cd.AddTrack("One", "7:24", "Hetfield, Ulrich");
                cd.AddTrack("The Shortest Straw", "6:35", "Hetfield, Ulrich");
                cd.AddTrack("Harvester Of Sorrow", "5:42", "Hetfield, Ulrich");
                cd.AddTrack("The Frayed Ends Of Sanity", "7:40", "Hetfield, Ulrich");
                cd.AddTrack("To Live Is to Die", "9:48", "Hetfield, Lars Ulrich, Cliff Burton");
                cd.AddTrack("Dyers Eve", "5:12", "Hetfield, Ulrich, Hammett");

                p.Add(cd);
            }

            {
                MusicCD cd = new MusicCD("Bruce Springsteen", "Chapter and Verse", 13.13m, 2016)
                {
                    Label = "Columbia Records",
                    ImageUrl = "bschapterandverse.jpg",
                    Category = category
                };
                cd.AddTrack("Baby I");
                cd.AddTrack("You Can't Judge a Book by the Cover");
                cd.AddTrack("He's Guilty (The Judge Song)");
                cd.AddTrack("The Ballad of Jesse James");
                cd.AddTrack("Henry Boy");
                cd.AddTrack("Growin' Up (Album Version)");
                cd.AddTrack("4th of July, Asbury Park (Sandy)");
                cd.AddTrack("Born to Run");
                cd.AddTrack("Badlands");
                cd.AddTrack("The River");
                cd.AddTrack("My Father's House");
                cd.AddTrack("Born in the U.S.A.");
                cd.AddTrack("Brilliant Disguise");
                cd.AddTrack("Living Proof");
                cd.AddTrack("The Ghost of Tom Joad");
                cd.AddTrack("The Rising");
                cd.AddTrack("Long Time Comin'");
                cd.AddTrack("Wrecking Ball");

                p.Add(cd);
            }

            return p;
        }

        /// <summary>
        /// Return movies.
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetMovies()
        {
            string category = "Movie";

            List<Product> p = new List<Product>();
            p.Add(new Movie("Jungle Book", 160.50m, "Jon Favreau") { ImageUrl = "junglebook.jpg", Category = category });
            p.Add(new Movie("Forrest Gump", 125.00m, "Robert Zemeckis") { ImageUrl = "forrest-gump.jpg", Category = category });
            p.Add(new Movie("Gladiator", 149.75m, "Ridley Scott") { ImageUrl = "gladiator.jpg", Category = category });

            return p;
        }

        /// <summary>
        /// Returns a random product.
        /// </summary>
        /// <returns></returns>
        public static Product GetRandomProduct()
        {
            // Get the products.
            List<Product> allProducts = GetBooks();
            allProducts.AddRange(GetMovies());
            allProducts.AddRange(GetMusicCDs());

            int min = 0;
            int max = allProducts.Count;
            int num = r.Next(min, max);
            return allProducts[num];
        }

    }
}