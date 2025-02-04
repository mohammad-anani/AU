using AU_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AU_Business
{
    public class clsPerson
    {
        public int PersonID { get; set; }

        public string FirsrtName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string FullName()
        {
            return this.FirsrtName + " " + this.SecondName + " " + this.LastName;
        }

        public string Phone { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        public int CountryID { get; set; }

        public clsCountry Country { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string ImagePath { get; set; }

        public enum enMode { Add, Update };

        public enMode Mode { get; set; }
        public clsPerson()
        {
            this.PersonID = -1;
            this.FirsrtName = "";
            this.SecondName = "";
            this.LastName = "";
            this.Phone = "";
            this.DateOfBirth = DateTime.MinValue;
            this.Gender = "";
            this.CountryID = -1;
            this.Country = new clsCountry();
            this.Username = "";
            this.Password = "";
            this.ImagePath = "";
            this.Mode = enMode.Add;
        }

        private clsPerson(int personID, string firstname, string secondname, string lastname, string phone, DateTime DateOfBirth, string gender,int
            countryid, string username, string password, string imagepath)
        {
            this.PersonID = personID;
            this.FirsrtName = firstname;
            this.SecondName = secondname;
            this.LastName = lastname;
            this.Phone = phone;
            this.DateOfBirth = DateOfBirth;
            this.Gender = gender;
            this.CountryID = countryid;
            this.Country=clsCountry.Find(countryid);
            this.Username = username;
            this.Password = password;
            this.ImagePath = imagepath;
            this.Mode = enMode.Update;

        }

        public static int ConvertGender(string gendername)
        {
            switch (gendername)
            {
                case "Male":
                    return 0;
                case "Female":
                    return 1;
                default:
                    return -1;
            }
        }

        public static string ConvertGender(int genderid)
        {
            switch (genderid)
            {
                case 0:
                    return "Male";
                case 1:
                    return "Female";
                default:
                    return "";
            }
        }


        private bool _AddPerson()
        {
            this.PersonID = clsPersonData.AddPerson(this.FirsrtName, this.SecondName, this.LastName, this.Phone, this.DateOfBirth,
                ConvertGender(this.Gender),this.CountryID, this.Username, this.Password, this.ImagePath);

            return this.PersonID != -1;
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.FirsrtName, this.SecondName, this.LastName, this.Phone, this.DateOfBirth,
                ConvertGender(this.Gender), this.Country.CountryID, this.Username, this.Password, this.ImagePath);
        }

        public bool Save()
        {
            if (this.Mode == enMode.Add)
            {
                if (this._AddPerson())
                    return true;
            }
            else if (this.Mode == enMode.Update)
            {
                if (this._UpdatePerson())
                    return true;
            }
            return false;
        }

        public static clsPerson Find(int personid)
        {

            string FirstName = "";
            string SecondName = "";
            string LastName = "";
            string Phone = "";
            DateTime DateOFBirth = DateTime.MinValue;
            int Gender = -1;
            int CountryID = -1;
            string Username = "";
            string Password = "";
            string ImagePath = "";

            if (clsPersonData.FindPersonByID(personid, ref FirstName, ref SecondName, ref LastName, ref Phone, ref DateOFBirth,
                ref Gender, ref CountryID, ref Username, ref Password, ref ImagePath))
            {
                return new clsPerson(personid, FirstName, SecondName, LastName, Phone, DateOFBirth
                    , ConvertGender(Gender), CountryID, Username, Password, ImagePath);
            }
            return new clsPerson();
        }

        public static clsPerson Find(string username, string password)
        {
            int personid = -1;
            string FirstName = "";
            string SecondName = "";
            string LastName = "";
            string Phone = "";
            DateTime DateOFBirth = DateTime.MinValue;
            int Gender = -1;
            int CountryID = -1;
            string ImagePath = "";

            if (clsPersonData.FindPersonByUsernamePassword(ref personid, ref FirstName, ref SecondName, ref LastName, ref Phone, ref DateOFBirth,
                ref Gender, ref CountryID, username, password, ref ImagePath))
            {
                return new clsPerson(personid, FirstName, SecondName, LastName, Phone, DateOFBirth
                    , ConvertGender(Gender), CountryID, username, password, ImagePath);
            }
            return new clsPerson();
        }


        public static clsPerson Find(string username)
        {
            int personid = -1;
            string FirstName = "";
            string SecondName = "";
            string LastName = "";
            string Phone = "";
            DateTime DateOFBirth = DateTime.MinValue;
            int Gender = -1;
            int CountryID = -1;
            string ImagePath = "";
            string password = "";

            if (clsPersonData.FindPersonByUsername(ref personid, ref FirstName, ref SecondName, ref LastName, ref Phone, ref DateOFBirth,
                ref Gender, ref CountryID, username,ref password, ref ImagePath))
            {
                return new clsPerson(personid, FirstName, SecondName, LastName, Phone, DateOFBirth
                    , ConvertGender(Gender), CountryID, username, password, ImagePath);
            }
            return new clsPerson();
        }



        public static DataTable ListPersons()
        {
            return clsPersonData.GetPersonsList();
        }

        public static DataTable ListUsernames()
        {
            return clsPersonData.GetUsernamesList();
        }

        public static bool DeletePerson(int personid)
        {
            return clsPersonData.DeletePerson(personid);
        }

        public static int GetPersonsCount()
        {
            return clsPersonData.GetPersonsCount();
        }

        public static bool PersonExists(int personid)
        {
            return clsPerson.Find(personid) != new clsPerson();
        }

        public static bool PersonExists(string username,string password)
        {
            return clsPerson.Find(username,password) != new clsPerson();
        }

        public static bool UsernameExists(string username)
        {
            return clsPersonData.UsernameExists(username);
        }

        public static DataTable GetUsernamesList(string query)
        {
            return clsPersonData.GetUsernamesList(query);
        }
    }
}
