using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Infrastructure
{
    public class SessionState
    {
        private Repository repository;
        private Customer currentCustomer;

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

        public Customer CurrentCustomer
        {
            get { return currentCustomer; }
            set { currentCustomer = value; }
        }
       

        public SessionState() { }
    }
}