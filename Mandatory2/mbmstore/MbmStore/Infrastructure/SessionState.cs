using MbmStore.Models;
using MbmStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Infrastructure
{
    public class SessionState
    {
        #region PrivateFields

        private Customer currentCustomer;

        #endregion

        #region Properties

        /// <summary>
        /// The current customer.
        /// </summary>
        public Customer CurrentCustomer
        {
            get { return currentCustomer; }
            set { currentCustomer = value; }
        }

        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SessionState() { }
    }
}