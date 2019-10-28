using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using _07WebAPI.Models;

namespace _07WebAPI.Controllers
{
    public class CourseController : ApiController
    {
        List<Course> courses = new List<Course>
        {
            new Course{ Id=1, Name="ASP.net MVC5",Hours=30},
            new Course{ Id=2, Name="ASP.net WebForm",Hours=50},
            new Course{ Id=3, Name="ASP",Hours=25},
            new Course{ Id=4, Name="PHP",Hours=30},
            new Course{ Id=5, Name="JavaScript",Hours=20},
            new Course{ Id=6, Name="HTML5",Hours=15},
            new Course{ Id=7, Name="jQuery",Hours=12},
            new Course{ Id=8, Name="SQL Server",Hours=40},
            new Course{ Id=9, Name="Android APP",Hours=45},
            new Course{ Id=10, Name="Bootstrap",Hours=25}
        };

        public IEnumerable<Course> Get() {
            return courses;
        }

    }
}