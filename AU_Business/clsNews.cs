using AU_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AU_Business
{
    public class clsNews
    {
        public int NewsID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public enum enMode { Add,Update}

        public enMode Mode { get; set; }

        public clsNews()
        {
            this.NewsID = -1;
            this.Title = "";
            this.Description = "";
            this.ImagePath = "";
            this.Mode = enMode.Add;
        }

        private clsNews(int newsID, string title, string description, string imagePath)
        {
            this.NewsID = newsID;
            this.Title = title;
            this.Description = description;
            this.ImagePath = imagePath;
            this.Mode = enMode.Update;
        }

        public static DataTable ListNews()
        {
            return clsNewsData.ListNews();
        }

        private bool _AddNews()
        {
            this.NewsID=clsNewsData.AddNews(this.Title, this.Description, this.ImagePath);
            return (this.NewsID!=-1);
        }

        private bool _UpdateNews()
        {
            return clsNewsData.UpdateNews(this.NewsID,this.Title, this.Description, this.ImagePath);
        }

        public bool Save()
        {
            if(this.Mode==enMode.Add)
            {
                if(this._AddNews())
                {
                    this.Mode=enMode.Update;
                    return true;
                }    
               
            }
            else if(this.Mode==enMode.Update)
            {
                return this._UpdateNews();
            }
            return false;
        }

        public static clsNews Find(int NewID)
        {
            string desc = "", title = "", imagepath = "";

            if(clsNewsData.FindNews(NewID,ref title,ref desc,ref imagepath))
            {
                return new clsNews(NewID,title,desc,imagepath);
            }

            return new clsNews();
        }
    }
}
