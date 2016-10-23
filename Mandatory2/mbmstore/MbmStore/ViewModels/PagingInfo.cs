using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.ViewModels
{
    public class PagingInfo
    {
        /// <summary>
        /// The current page.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// The number of items per page.
        /// </summary>
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// The total number of items.
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// The total number of page.
        /// </summary>
        public int TotalPages
        {
            get
            {
                int tp = (TotalItems - 1) / ItemsPerPage + 1;
                return tp;
            }
        }
    }
}