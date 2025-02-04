using AU_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Business
{
    public class clsExam
    {
        public int ExamID { get; set; }

        public int ScheduledCourseID { get; set; }

        public clsScheduledCourse ScheduledCourse=new clsScheduledCourse();

        public string Code { get; set; }

        public int Duration { get; set; }

        public bool IsTaken { get; set; }

        public int NumberOfQuestions { get; set; }


        private clsExam(int examid, string code,int scheduledcourseid, int numberOfQuestions,int duration)
        {
            this.ExamID = examid;
           this.Code = code;
           this.NumberOfQuestions = numberOfQuestions;
           this.Duration = duration;
            this.ScheduledCourseID = scheduledcourseid;
            this.ScheduledCourse=clsScheduledCourse.Find(scheduledcourseid);
        }

        public clsExam()
        {
            this.ExamID = -1;
            this.ScheduledCourseID = -1;
            this.ScheduledCourse = new clsScheduledCourse();
            this.Code = "";
            this.Duration = -1;
            this.IsTaken = false;
            this.NumberOfQuestions = -1;
        }

        public bool AddExam()
        {
            this.ExamID = clsExamData.AddExam(this.ScheduledCourseID, this.Code, this.Duration);
            return this.ExamID != -1;
        }

        public bool UpdateExam()
        {
            return clsExamData.UpdateExam(this.Code,this.Duration,this.IsTaken);
        }

        public static DataTable ListExamsForTeachers(int teacherid)
        {
            return clsExamData.ListExamsForTeachers(teacherid);
        }

        public static DataTable ListExamsForStudents(int studentid)
        {
            return clsExamData.ListExamsForStudents(studentid);
        }

        public static clsExam Find(string code,int scheduledcourseid)
        {
            int duration= -1;
            int examid = -1;
            int numberofquestions= -1;
            

            if(clsExamData.FindExamByCode(code,ref examid,scheduledcourseid,ref duration,ref numberofquestions))
            {
                return new clsExam(examid,code,scheduledcourseid,numberofquestions,duration);
            }
            return new clsExam();
        }

        public static clsExam Find(string code)
        {
            int duration = -1;
            int examid = -1;
            int numberofquestions = -1;
            int scheduledcourseid = -1;


            if (clsExamData.FindExamByCode(code, ref examid,ref scheduledcourseid, ref duration, ref numberofquestions))
            {
                return new clsExam(examid, code, scheduledcourseid, numberofquestions, duration);
            }
            return new clsExam();
        }
    }
}
