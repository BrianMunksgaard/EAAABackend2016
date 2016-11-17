using Lesson10Exercises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson10Exercises.Infrastructure
{
    public class UserRepository
    {
        private List<User> users;

        /// <summary>
        /// Return all users.
        /// </summary>
        public List<User> Users
        {
            get { return users; }
        }

        /// <summary>
        /// User repository constructor.
        /// </summary>
        public UserRepository()
        {
            users = new List<User>();
            users.Add(new User { Name = "Peter Nielsen", Username = "peter", Password = "ptr3nls", Age = 24 });
            users.Add(new User { Name = "Thomas Larsen", Username = "tmlar", Password = "thm14lar", Age = 32 });
            users.Add(new User { Name = "Vibeke Hansen", Username = "vibe", Password = "vibe2hanse", Age = 22 });
            users.Add(new User { Name = "Susan Olsen", Username = "suol", Password = "susanol", Age = 34 });
        }

        public bool UsernameIsUnique(string username)
        {
            bool unique = false;
            if (!string.IsNullOrEmpty(username))
            {
                User currentUser = Users.SingleOrDefault(u => u.Username == username);
                unique = currentUser == null;
            }
            return unique;
        }
    }
}