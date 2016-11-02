using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.ViewModels
{
    /// <summary>
    /// This class holds shipping details used
    /// when the user performs a checkout.
    /// </summary>
    public class ShippingDetails
    {
        /// <summary>
        /// Ship to first name.
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Ship to last name.
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Ship to address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Ship to zip code.
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// Ship to city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Ship to country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Email address of ship to person.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Whether or not the package should be gift wrapped.
        /// </summary>
        public bool GiftWrap { get; set; }
    }
}