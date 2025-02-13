using AU_Business;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Security.Claims;

namespace AU_Web.Controllers
{
    [Route("api/AU")]
    [ApiController]
    public class AUController : ControllerBase
    {

        //[HttpGet("GetStudents")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult GetStudents()
        //{
        //    List<object> students = clsUtil.DatatableToList(clsStudent.Liststudents());
        //    if(students.Any())
        //    {
        //        return Ok(students);
        //    }
        //    else
        //    {
        //        return NotFound("No students.");
        //    }
        //}

        public class clsLoginCredentials
        {
            public string Username { get; set; } 
            public string Password { get; set; } 

            public clsLoginCredentials(string username, string password)
            {
                Username = username;
                Password = password;
            }
        }


        [HttpGet("GetReceivedEmails/{PersonID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetReceivedEmails(int PersonID)
        {
            List<object> emails = clsUtil.DatatableToList(clsEmail.ListReceivedEmails(PersonID));
            if (emails.Any())
            {
                return Ok(emails);
            }
            else
            {
                return NotFound("No emails.");
            }
        }

        [HttpGet("GetUnopenedEmails/{PersonID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetUnopenedEmails(int PersonID)
        {
            List<object> emails = clsUtil.DatatableToList(clsEmail.ListUnopenedEmails(PersonID));
            if (emails.Any())
            {
                return Ok(emails);
            }
            else
            {
                return NotFound("No new emails.");
            }
        }

        [HttpGet("GetSentEmails/{PersonID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetSentEmails(int PersonID)
        {
            List<object> emails = clsUtil.DatatableToList(clsEmail.ListSentEmails(PersonID));
            if (emails.Any())
            {
                return Ok(emails);
            }
            else
            {
                return NotFound("No emails.");
            }
        }

        [HttpGet("GetEmailbyID/{EmailID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult GetEmailbyID(int EmailID)
        {
            if (EmailID<1)
            {
                return BadRequest($"Invalid ID:{EmailID}");
            }

            clsEmail email = clsEmail.Find(EmailID);

            if (email.EmailID == -1)
            {
                return NotFound($"Email with ID:{EmailID} not found.");
            }

            email.FromPerson.ImagePath = clsUtil.SaveToWebDirectory(email.FromPerson.ImagePath, "PFPs");
            email.ToPerson.ImagePath = clsUtil.SaveToWebDirectory(email.ToPerson.ImagePath, "PFPs");

            return Ok(email);
        }



     

        [HttpGet("GetSessionsForStudent/{StudentID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetSessionsForStudent(int StudentID)
        {
            if(StudentID<1)
            {
                return BadRequest($"Invalid ID:{StudentID}.");
            }
            List<object> sessions = clsUtil.DatatableToList(clsSession.ListSessionsForStudent(StudentID));
            if (sessions.Any())
            {
                return Ok(sessions);
            }
            else
            {
                return NotFound("No sessions.");
            }
        }

        [HttpGet("GetScheduledCoursesForStudent/{StudentID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetScheduledCoursesForStudent(int StudentID)
        {
            if (StudentID < 1)
            {
                return BadRequest($"Invalid ID:{StudentID}.");
            }
            List<object> scheduledcourses = clsUtil.DatatableToList(clsScheduledCourse.ListScheduledCoursesForStudent(StudentID));
            if (scheduledcourses.Any())
            {
                return Ok(scheduledcourses);
            }
            else
            {
                return NotFound("No scheduled courses.");
            }
        }


        [HttpGet("GetEnrolledCoursesForStudent/{StudentID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetEnrolledCoursesForStudent(int StudentID)
        {
            if (StudentID < 1)
            {
                return BadRequest($"Invalid ID:{StudentID}.");
            }
            List<object> enrolledcourses = clsUtil.DatatableToList(clsEnrolledCourse.ListEnrolledCoursesForStudent(StudentID));
            if (enrolledcourses.Any())
            {
                return Ok(enrolledcourses);
            }
            else
            {
                return NotFound("No enrolled courses.");
            }
        }


     

        [HttpGet("GetEnrolledCourseByID/{EnrolledCourseID}",Name = "GetEnrolledCourseByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetEnrolledCourseByID(int EnrolledCourseID)
        {
            if (EnrolledCourseID < 1)
            {
                return BadRequest($"Invalid ID:{EnrolledCourseID}.");
            }

            clsEnrolledCourse EnrolledCourse = clsEnrolledCourse.Find(EnrolledCourseID);

            if (EnrolledCourse.EnrolledCourseID==-1)
            {
                return NotFound($"Enrolled course with ID:{EnrolledCourseID} not found.");
            }
            else
            {
                return Ok(EnrolledCourse);
            }
        }



       

        [HttpGet("GetLatestNews")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetLatestNews()
        {
            
            List<object> news = clsUtil.DatatableToList(clsNews.ListNews());
            if (news.Any())
            {
                return Ok(news.TakeLast(3));
            }
            else
            {
                return NotFound("No news.");
            }
        }


        [HttpGet("GetNewsByID/{NewsID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetNewsByID(int NewsID)
        {
            if (NewsID < 1)
            {
                return BadRequest($"Invalid ID:{NewsID}.");
            }

           clsNews News=clsNews.Find(NewsID);

            if (News.NewsID == -1)
            {
                return NotFound($"News with ID:{NewsID} not found.");
            }
            else
            {
                News.ImagePath=clsUtil.SaveToWebDirectory(News.ImagePath,"News");
                return Ok(News);
            }
        }

        [HttpGet("GetStudentByID/{StudentID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult GetStudentByID(int StudentID)
        {
            if (StudentID < 1)
            {
                return BadRequest($"Invalid ID:{StudentID}.");
            }

            clsStudent Student = clsStudent.FindStudentByID(StudentID);

            if (Student.StudentID == -1)
            {
                return NotFound($"Student with ID:{StudentID} not found.");
            }
            else
            {
                Student.Person.ImagePath=clsUtil.SaveToWebDirectory(Student.Person.ImagePath,"PFPs");
                return Ok(Student);
            }

        }



        [HttpPost("GetStudentByUsernameAndPassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult GetStudentByUsernameAndPassword([FromBody] clsLoginCredentials credentials)
        {
            if (string.IsNullOrEmpty(credentials.Username) || string.IsNullOrEmpty(credentials.Password))
            {
                return BadRequest($"Invalid username and/or password");
            }

            if (!clsPerson.PersonExists(credentials.Username, credentials.Password))
            {
                return NotFound($"Student not found.");
            }

            clsStudent student = clsStudent.FindStudentByPersonID(clsPerson.Find(credentials.Username, credentials.Password).PersonID);


            if (student.StudentID != -1)
            {
                //var claims = new List<Claim>
                //{
                //    new Claim("StudentID",student.StudentID.ToString()),
                //    new Claim(ClaimTypes.Role,"Student")
                //};

                //var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //var principal = new ClaimsPrincipal(identity);

                //var authProperties = new AuthenticationProperties
                //{
                //    IsPersistent = true,
                //    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
                //};

                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

                //Response.Cookies.Append("StudentID",student.StudentID.ToString(),new CookieOptions
                //{
                //    Expires = DateTimeOffset.UtcNow.AddDays(1),
                //    HttpOnly = true,
                //    Secure = true, 
                //    SameSite = SameSiteMode.Lax
                //});
                return Ok(new {StudentID=student.StudentID });
            }
            else
            {
                return NotFound($"Student not found.");
            }

        }

      

        [HttpPost("AddEnrolledCourse/{StudentID}/{ScheduledCourseID}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult AddEnrolledCourses(int StudentID, int ScheduledCourseID)
        {
            if (StudentID < 1 || ScheduledCourseID < 1)
            {
                return BadRequest("Invalid student and/or scheduled course ID");
            }

            clsEnrolledCourse NewEnrolledCourse = new clsEnrolledCourse();
            NewEnrolledCourse.StudentID = StudentID;
            NewEnrolledCourse.ScheduledCourseID = ScheduledCourseID;

            if (NewEnrolledCourse.EnrollCourse())
            {
                return CreatedAtRoute("GetEnrolledCourseByID", new { EnrolledCourseID = NewEnrolledCourse.EnrolledCourseID }, NewEnrolledCourse);
            }
            else
            {
                return NotFound("Student or scheduled course not found");
            }
        }


        [HttpPut("UpdateEmail")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateEmail([FromBody] clsEmail Email)
        {
            if (Email == null || Email.EmailID < 1)
            {
                return BadRequest("Invalid email");
            }

            if (Email.Save())
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, "An internal server error occurred.");
            }
        }


        [HttpPut("UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdatePerson([FromBody] clsPerson Person)
        {
            if (Person == null || Person.PersonID < 1)
            {
                return BadRequest("Invalid Person");
            }

            if (!clsPerson.PersonExists(Person.PersonID))
            {
                return NotFound($"Person with ID:{Person.PersonID} not found");
            }

            if (Person.Save())
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, "An internal server error occurred.");
            }
        }



        [HttpPut("OpenEmail")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult OpenEmail([FromBody] clsEmail Email)
        {
            if (Email == null || Email.EmailID < 1)
            {
                return BadRequest("Invalid email");
            }

            if (Email.OpenEmail())
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, "An internal server error occurred.");
            }
        }


        [HttpDelete("DeleteEnrolledCourseByID/{EnrolledCourseID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteEnrolledCourseByID(int EnrolledCourseID)
        {
            if (EnrolledCourseID < 1)
            {
                return BadRequest($"Invalid ID:{EnrolledCourseID}.");
            }

            if (clsEnrolledCourse.DropCourse(EnrolledCourseID))
            {
                return NoContent();
            }
            else
            {
                return NotFound($"Enrolled course with ID:{EnrolledCourseID} not found.");
            }
        }

    }
}
