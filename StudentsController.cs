using Microsoft.AspNetCore.Mvc;

namespace mymvcapp.Controllers
{
    public class StudentsController : Controller
    {
     public ContentResult Hello()   //string+html
        {
            return Content("<font color='blue'>Hello world</font>", "text/html");
        }
        public ViewResult sat()
        {
            return View();
        }
        public ViewResult homepage()
        {
            return View();
        }
        public ViewResult aboutus()
        {
            return View();
        }
        public ViewResult para(int id)
        {if (id < 10)
            {
                return View("v1");
            }
            else
            {
                return View("v2");
            }
        }
        public ViewResult indi()
        {
            //only current method to current view page
            //becomes null if u navigate
            //data stored in object format
            ViewData["a"] = "Hello";
            ViewData["p"] = 10;
            ViewData["q"] = 20;
            //only current method to current view page
            //becomes null if u navigate
            //dynamic in nature
            ViewBag.abc = "chennai";
            ViewBag.a = 10;
            ViewBag.ab = 20;
            ViewBag.countrynames=new string[] { "india", "canada" };
            ViewBag.data = new int[] { 3, 45, 43, 3, 23 };
            
            ViewBag.Names=new string[] { "Rohit", "sachin", "Dhoni", "Virat", "Raina" };
            //can be used across multiple view pages
            TempData["t"] = "asp.net";
            TempData.Keep();
            return View();
        }
        [ActionName("gm")]
        public string goodmorning()
        {
            return "hi";
        }
        [NonAction]//now calling this method is not possible
        public string hot()
        {
            //any logic which you do not want to expose to end user use this
            return "weather is very hot";
        }
     /*   [HttpGet]
        public ViewResult Add()
        {
            return View();
        }
        [HttpPost] //will be called when submit is clicked
        public ViewResult Add(string t1,string t2)
        {
            int result=int.Parse(t1)+int.Parse(t2);
            ViewData["t"] ="the sum is "+ result;
            return View();
        }*/
        //if we have more variables we have to use Iform collection
        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }
        [HttpPost] //will be called when submit is clicked
        public ViewResult Add(IFormCollection f)
        {
            int result = int.Parse(f["t1"]) + int.Parse(f["t2"]);
            ViewData["t"] = "the sum is " + result;
            return View();
        }
        [HttpGet]
        public ViewResult logins()
        {
            return View();
        }
        [HttpPost]
        public ViewResult logins(string t1, string t2)
        {
            string s = "";
            if(t1=="admin" && t2=="india")
            {
                s = "user is valid";
            }
            else
            {
                 s = "user is not valid";
            }
                
            ViewData["e"] =s;
            return View();
        }

    }
}
