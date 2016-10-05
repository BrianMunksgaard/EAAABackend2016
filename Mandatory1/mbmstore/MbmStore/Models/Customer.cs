using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Models
{
    /// <summary>
    /// MbmStore customer information.
    /// </summary>
    public class Customer
    {

        #region PrivateFields

        private int customerId;
        private string firstName;
        private string lastName;
        private string address;
        private string zip;
        private string city;
        private DateTime birthDay;
        private List<string> phoneNumbers;

        #endregion

        #region Properties

        public int CustomerId
        {
            get
            {
                return customerId;
            }
        }

        /// <summary>
        /// Customer first name.
        /// </summary>
        public string FirstName
        {
            get { return firstName == null ? firstName = string.Empty : firstName; }
            set { firstName = value; }
        }

        /// <summary>
        /// Customer last name.
        /// </summary>
        public string LastName
        {
            get { return lastName == null ? lastName = string.Empty : lastName; }
            set { lastName = value; }
        }

        /// <summary>
        /// Customer address.
        /// </summary>
        public string Address
        {
            get { return address == null ? address = string.Empty : address; }
            set { address = value; }
        }

        /// <summary>
        /// Customer zip code.
        /// </summary>
        public string Zip
        {
            get { return zip == null ? zip = string.Empty : zip; }
            set { zip = value; }
        }

        /// <summary>
        /// Customer city.
        /// </summary>
        public string City
        {
            get { return city == null ? city = string.Empty : city; }
            set { city = value; }
        }

        /// <summary>
        /// Customer birthday. Birthday has to be
        /// between 0 and 120 years, both included.
        /// </summary>
        public DateTime BirthDay
        {
            get { return birthDay; }
            set
            {
                DateTime now = DateTime.Now;
                if (value >= now.AddYears(-120) && value <= now)
                {
                    birthDay = value;
                }
                else
                {
                    throw new Exception("Birthday not accepted");
                }
            }
        }

        /// <summary>
        /// Returns the customer age in a string.
        /// </summary>
        public string Age
        {
            get
            {
                if (BirthDay == DateTime.MinValue)
                {
                    return "Unknown";
                }
                else
                {
                    DateTime now = DateTime.Now;
                    int age = now.Year - BirthDay.Year;
                    // calculate to see if the customer hasn’t had birthday yet
                    // subtract one year if that is so.
                    if (now.Month < BirthDay.Month || (now.Month == BirthDay.Month && now.Day < BirthDay.Day))
                    {
                        age--;
                    }

                    return age.ToString();
                }
            }
        }

        /// <summary>
        /// The list of customer phone numbers.
        /// </summary>
        public List<string> PhoneNumbers
        {
            get
            {
                if(phoneNumbers == null)
                {
                    phoneNumbers = new List<string>();
                }
                return phoneNumbers;
            }
        }

        /// <summary>
        /// Return all phone numbers in a concatinated string.
        /// Numbers are seperated by comma.
        /// </summary>
        public string AllPhoneNumbers
        {
            get
            {
                if (PhoneNumbers.Count > 0)
                {
                    return string.Join(", ", PhoneNumbers);
                }
                else
                {
                    return "No phone";
                }
            }
        }

        #endregion

        /// <summary>
        /// Initialization constructor.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="zip"></param>
        /// <param name="city"></param>
        public Customer(string firstName, string lastName, string address, string zip, string city)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.zip = zip;
            this.city = city;
        }

        /// <summary>
        /// Initialization constructor.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="zip"></param>
        /// <param name="city"></param>
        public Customer(int customerId, string firstName, string lastName, string address, string zip, string city) : this(firstName, lastName, address, zip, city)
        {
            this.customerId = customerId;
        }


        /// <summary>
        /// Add customer phone number.
        /// </summary>
        /// <param name="phoneNumber"></param>
        public void AddPhoneNumber(string phoneNumber)
        {
            if(!string.IsNullOrEmpty(phoneNumber)) {
                PhoneNumbers.Add(phoneNumber);
            }
        }

    }
}