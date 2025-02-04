using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using AU_Data;
using System.Data;

namespace AU_Business
{
    public class clsBorrowing
    {
        public int BorrowingID { get; set; }

        public int BookID { get; set; }

        public clsBook Book { get; set; }

        public int StudentID { get; set; }

        public clsStudent Student { get; set; }

        public DateTime BorrowDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public double Rating { get; set; }

        public double PaidFees { get; set; }

        public clsBorrowing()
        {
            this.BorrowingID = -1;
            this.BookID = -1;
            this.StudentID = -1;
            this.BorrowDate = DateTime.MinValue;
            this.ReturnDate = DateTime.MinValue;
            this.DueDate = DateTime.MinValue;
            this.PaidFees = -1;
            this.Rating = -1;
        }

        public clsBorrowing(int borrowid, int bookid,int studentid,DateTime borrowdate,DateTime DueDate,DateTime returndate,double Rating,double PaidFees)
        {
            this.BorrowDate=borrowdate;
            this.BookID = bookid;
            this.StudentID = studentid;
            this.BorrowingID = borrowid;
            this.Student = clsStudent.FindStudentByID(studentid);
            this.Book = clsBook.Find(bookid);
            this.Rating = Rating;
            this.DueDate= DueDate;
            this.ReturnDate = ReturnDate;
            this.PaidFees= PaidFees;
        }

        public bool AddBorrorwing()
        {
            string Activated = File.ReadAllText("AU_Settings.txt");
            this.DueDate = DateTime.Now.AddDays(Convert.ToInt32(Activated.Substring(6, 2)));
            this.BorrowingID = clsBorrowingData.AddBorrowing(this.BookID, this.StudentID, DateTime.Now,this.DueDate);
            return this.BorrowingID != -1;
        }

        public bool ReturnBook()
        {
            return clsBorrowingData.ReturnBook(this.BorrowingID, DateTime.Now, this.Rating,this.PaidFees);
        }

        public static clsBorrowing Find(int borrowid)
        {
            int BookID = -1;
            int StudentID = -1;
          DateTime BorrowDate = DateTime.MinValue;
           double PaidFees = -1;
            DateTime ReturnDate = DateTime.MinValue;
            DateTime DueDate = DateTime.MinValue; 
            double Rating = -1;

            if(clsBorrowingData.FindBorrowing(borrowid,ref BookID,ref StudentID,ref BorrowDate,ref DueDate,ref ReturnDate,ref  Rating,ref PaidFees))
            {
                return new clsBorrowing(borrowid,BookID,StudentID,BorrowDate,DueDate,ReturnDate,Rating,PaidFees);
            }
            return new clsBorrowing();
                    
        }

        public static DataTable ListBorrowings(bool all)
        {
            return clsBorrowingData.ListBorrowings(all);
        }

     
    }
}
