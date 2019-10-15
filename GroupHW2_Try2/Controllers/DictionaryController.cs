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
        //Method to add 1 item 
        public ActionResult AddOne()
        {
            int iPlace;
            iPlace = myDictionary.Count() + 1;
            myDictionary.Add("New Entry " + (myDictionary.Count + 1).ToString() , (myDictionary.Count + 1));


            return View("Index");
        }
        //Method to add 2,000 items
        public ActionResult AddHuge()
        {
            myDictionary.Clear();
            //Loop to increment each dictionary addition
            for (int i = 0; i < 2000; i++)
            {
                int iPosition = i + 1;
                myDictionary.Add("New Entry " + (myDictionary.Count + 1).ToString(), (myDictionary.Count + 1));
            }
            return View("Index");
        }
        //Method to display dictionary on web page
        public ActionResult Display()
        {
            ViewBag.MyDictionary = myDictionary;
            return View("Display");
        }
        //Method to delete 1 dictionary entry
        public ActionResult Delete()
        {
            //Check to see dictionary count and delete result.
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
        //Method to clear all dictionary entries
        public ActionResult Clear()
        {
            myDictionary.Clear();
            return View("Index");
        }
        //Method to search dictionary for search criteria
        public ActionResult Search()
        {
            string searchCriteria = "New Entry 5";
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //Check if dictionary is empty
            if (myDictionary.Count() > 0)
            {
                sw.Start();
                //Check each dictionary entry for search criteria
                for (int i = 0; i < myDictionary.Count(); i++)
                {
                    sw.Start();
                    //Print search attempt result
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
