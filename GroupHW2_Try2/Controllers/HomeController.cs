using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupHW2_Try2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //Show home page
            return View();
        }

        public ActionResult Exit()
        {
            //Take to BYU home page
            return Redirect("https://www.byu.edu");
        }
    }
}