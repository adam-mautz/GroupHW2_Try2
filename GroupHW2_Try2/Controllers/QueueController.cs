using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace DataStructuresHW2_AmberHewitt.Controllers
{
    public class QueueController : Controller
    {
        static Queue<string> myQueue = new Queue<string>();

        // GET: Stack
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddOne()
        {
            int iPlace;
            iPlace = myQueue.Count() + 1;
            myQueue.Enqueue("New Entry " + iPlace.ToString());


            return View("Index");
        }

        public ActionResult AddHuge()
        {
            myQueue.Clear();
            for (int i = 0; i < 2000; i++)
            {
                int iPosition = i + 1;
                myQueue.Enqueue("New Entry " + iPosition.ToString());
            }
            return View("Index");
        }

        public ActionResult Display()
        {
            ViewBag.MyQueue = myQueue;
            return View("Display");

        }

        public ActionResult Delete()
        {
            if (myQueue.Count > 0)
            {
                myQueue.Dequeue();
            }
            else
            {
                ViewBag.Delete = "There are no items in the queue to delete!";
            }

            return View("Index");
        }

        public ActionResult Clear()
        {
            myQueue.Clear();
            return View("Index");
        }

        public ActionResult Search()
        {
            string searchCriteria = "New Entry 5";
            bool searchFound = false;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            if (myQueue.Count() > 0)
            {
                sw.Start();
                for (int i = 0; i < myQueue.Count(); i++)
                {
                    if (searchCriteria == myQueue.ElementAt(i))
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