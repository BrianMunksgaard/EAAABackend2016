using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }

        private DateTime birthDay;
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
        
        private List<string> phoneNumbers;
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

        public Customer(string firstName, string lastName, string address, string zip, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Zip = zip;
            City = city;
        }

        public void AddPhoneNumber(string phoneNumber)
        {
            if(!string.IsNullOrEmpty(phoneNumber)) {
                PhoneNumbers.Add(phoneNumber);
            }
        }

    }
}