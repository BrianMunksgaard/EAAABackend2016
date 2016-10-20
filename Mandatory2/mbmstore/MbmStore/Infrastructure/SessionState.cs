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

        private Repository repository;
        private Customer currentCustomer;
        private Cart shoppingCart;

        #endregion

        #region Properties

        /// <summary>
        /// Reference to the reporistory.
        /// </summary>
        public Repository Repository
        {
            get
            {
                if(repository == null)
                {
                    repository = new Repository();
                }
                return repository;
            }
            set
            {
                repository = value;
            }
        }

        /// <summary>
        /// The current customer.
        /// </summary>
        public Customer CurrentCustomer
        {
            get { return currentCustomer; }
            set { currentCustomer = value; }
        }

        /// <summary>
        /// The current shopping cart.
        /// </summary>
        public Cart ShoppingCart
        {
            get { return shoppingCart == null ? shoppingCart = new Cart() : shoppingCart; }
        }

        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SessionState() { }
    }
}