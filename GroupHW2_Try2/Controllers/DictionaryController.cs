using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupHW2_Try2.Controllers
{
    public class DictionaryController : Controller
    {
        static Dictionary<string, int> myDictionary = new Dictionary<string, int>();

        // GET: Stack
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddOne()
        {
            int iPlace;
            iPlace = myDictionary.Count() + 1;
            myDictionary.Add("New Entry " + (myDictionary.Count + 1).ToString() , (myDictionary.Count + 1));


            return View("Index");
        }

        public ActionResult AddHuge()
        {
            myDictionary.Clear();
            for (int i = 0; i < 2000; i++)
            {
                int iPosition = i + 1;
                myDictionary.Add("New Entry " + (myDictionary.Count + 1).ToString(), (myDictionary.Count + 1));
            }
            return View("Index");
        }

        public ActionResult Display()
        {
            ViewBag.MyDictionary = myDictionary;
            return View("Display");
        }

        public ActionResult Delete()
        {
            if (myDictionary.Count > 0)
            {
                myDictionary.Remove("New Entry 1");
            }
            else
            {
                ViewBag.Delete = "There are no items in the stack to delete!";
            }

            return View("Index");
        }

        public ActionResult Clear()
        {
            myDictionary.Clear();
            return View("Index");
        }

        public ActionResult Search()
        {
            string searchCriteria = "New Entry 5";
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            if (myDictionary.Count() > 0)
            {
                sw.Start();
                for (int i = 0; i < myDictionary.Count(); i++)
                {
                    sw.Start();

                    if (searchCriteria == ("New Entry " + (i + 1).ToString()))
                    {
                        ViewBag.Search = searchCriteria + " was successfully found in ";
                        break;
                    }
                    else
                    {
                        ViewBag.Search = searchCriteria + " could not be found. This search took ";
                    }
                    sw.Stop();

                }
            }
            else
            {
                sw.Stop();
                ViewBag.Search = searchCriteria + " could not be found. This search took ";

            }
            TimeSpan ts = sw.Elapsed;
            ViewBag.Search += ts;

            return View("Index");
        }
    }
}
