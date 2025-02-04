using AU_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Business
{
    public class clsBook
    {
        public int BookID { get; set; }

        public string BookName { get; set; }

        public string BookAuthor { get; set; }

        public int NumberOfCopies { get; set; }

        public int AvailableCopies { get; set; }

        public clsBook()
        {
            this.BookID = -1;
            this.BookAuthor = "";
            this.BookName = "";
            this.AvailableCopies = -1;
            this.NumberOfCopies = -1;
        }

        public clsBook(int bookID, string bookName, string bookAuthor, int numberOfCopies,int availablecopies)
        {
            this.BookID = bookID;
            this.BookName = bookName;
            this.BookAuthor = bookAuthor;
            this.NumberOfCopies = numberOfCopies;
            this.AvailableCopies = availablecopies;
        }

        private bool AddBook()
        {
            this.BookID=clsBooksData.AddBook(this.BookName, this.BookAuthor,this.NumberOfCopies);
            return this.BookID != -1;
        }

        private bool UpdateBook()
        {
            return clsBooksData.UpdateBook(this.BookID,this.BookName, this.BookAuthor, this.NumberOfCopies);
        }

        public bool Save()
        {
            if(this.BookID==-1)
            {
                return this.AddBook();
            }
            else if(this.BookID!=-1)
            {
                return this.UpdateBook();
            }
            return false;
        }

        public static DataTable ListBooks()
        {
            return clsBooksData.ListBooks();
        }

        public static clsBook Find(int BookID)
        {
            string name = "";
            string author = "";
            int acopies = -1;
            int numberOfCopies = -1;

            if (clsBooksData.FindBook(BookID,ref name,ref author,ref numberOfCopies,ref acopies))
            {
                return new clsBook(BookID,name,author,numberOfCopies,acopies);
            }
            return new clsBook();
        }

        public static bool DeleteBook(int bookid)
        {
            return clsBooksData.DeleteBook(bookid);
        }
    }
}
