using AU_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU_Business
{
    public class clsQuestion
    {

        public static bool AddQuestion(int number,int examid,int rightanswer)
        {
            return clsQuestionData.AddQuestion(examid, number, rightanswer)!=-1;
        }

        public static DataTable GetAnswers(int examid)
        {
            return clsQuestionData.GetAnswersList(examid);
        }

    }
}
