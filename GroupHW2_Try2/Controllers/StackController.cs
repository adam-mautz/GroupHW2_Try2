using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupHW2_Try2.Controllers
{

    public class StackController : Controller
    {
        static Stack<string> myStack = new Stack<string>();

        // GET: Stack
        public ActionResult Index()
        {
            return View();
        }
        //Method to add 1 item to stack
        public ActionResult AddOne()
        {
            int iPlace;
            iPlace = myStack.Count() + 1;
            myStack.Push("New Entry " + iPlace.ToString());
            

            return View("Index");
        }
        //Method to add 2000 items to the stack
        public ActionResult AddHuge()
        {
            myStack.Clear();
            //For loop to add new entries till 2000
            for (int i = 0; i < 2000; i++)
            {
                int iPosition = i + 1;
                myStack.Push("New Entry " + iPosition.ToString());
            }
            return View("Index");
        }
        //Method to display items in stack
        public ActionResult Display()
        {
            ViewBag.MyStack = myStack;
            return View("Display");

        }
        //Method to delete item in stack
        public ActionResult Delete()
        {
            //checks to see if there are items in stack, deletes or prints
            if(myStack.Count > 0)
            {
                myStack.Pop();
            }
            else
            {
                ViewBag.Delete = "There are no items in the stack to delete!";
            }

            return View("Index");
        }
        //Method to clear items
        public ActionResult Clear()
        {
            myStack.Clear();
            return View("Index");
        }
        //Method to search for search criteria within items in the stack
        public ActionResult Search()
        {
            string searchCriteria = "New Entry 5";
            bool searchFound = false;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //checks to see if there are items
            if (myStack.Count() > 0)
            {
                sw.Start();
                //loops to find search criteria
                for (int i = 0; i < myStack.Count(); i++)
                {
                    //prints search criteria
                    if (searchCriteria == myStack.ElementAt(i))
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