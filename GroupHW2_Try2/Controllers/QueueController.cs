using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace DataStructuresHW2_AmberHewitt.Controllers
{
    public class QueueController : Controller
    {
        //Create Queue
        static Queue<string> myQueue = new Queue<string>();

        // GET: Stack
        public ActionResult Index()
        {
            return View();
        }
        //Add item to queue
        public ActionResult AddOne()
        {
            int iPlace;
            iPlace = myQueue.Count() + 1;
            myQueue.Enqueue("New Entry " + iPlace.ToString());


            return View("Index");
        }
        //Add 2000 items to queue
        public ActionResult AddHuge()
        {
            myQueue.Clear();
            //Increment items until 2000
            for (int i = 0; i < 2000; i++)
            {
                int iPosition = i + 1;
                myQueue.Enqueue("New Entry " + iPosition.ToString());
            }
            return View("Index");
        }
        //Display items in queue
        public ActionResult Display()
        {
            ViewBag.MyQueue = myQueue;
            return View("Display");

        }
        //Delete items in queue
        public ActionResult Delete()
        {
            //Check to see items in queue and show result
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
        //Method to clear the queue
        public ActionResult Clear()
        {
            myQueue.Clear();
            return View("Index");
        }
        //Method to search the queue for search criteria
        public ActionResult Search()
        {
            string searchCriteria = "New Entry 5";
            bool searchFound = false;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //If statement to see if there are items in queue
            if (myQueue.Count() > 0)
            {
                sw.Start();
                //Finds search criteria within the queue
                for (int i = 0; i < myQueue.Count(); i++)
                {
                    //Prints search criteria results
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