using Microsoft.AspNetCore.Mvc;
using mymvcapp.Models;

namespace mymvcapp.Controllers
{
    
    public class MyPizzaController : Controller
    {
        pizzadbContext db=new pizzadbContext();
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(IFormCollection f)
        {
            string uname = f["uname"];
            string pwd = f["pwd"];
            var res=(from t in db.Registrations where t.Uname== uname && t.Password==pwd
                    select t).Count();
            if(res>0)
            {
                HttpContext.Session.SetString("u", uname);
                return RedirectToAction("Menu");
            }
            else
            {
                ViewBag.err = "Invalid username or password";
            }
            return View();
        }
        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Register(Registration reg)//table name to import the data to the table
        {
            if (ModelState.IsValid)//if all property values are correct it wil execute
            {
                db.Registrations.Add(reg);
                var res = db.SaveChanges();
                if (res > 0)
                {
                    ViewBag.msg = "Registration successful";
                }
                else
                {
                    ViewBag.msg = "Registration unsuccessful";
                }
               
            }
            return View();
        }
        public ViewResult Menu()
        {
            var res = (from t in db.Pizzas select t).ToList();
            return View(res);
        }
        [HttpGet]
        public ViewResult Cart(string pid)      //pid for menu to cart
        {
            var res = (from t in db.Pizzas where t.Pizzaid == pid select t).ToList();
            return View(res);
        }
        [HttpPost]
        public IActionResult Cart(IFormCollection f, string pid)
        {
            if (ModelState.IsValid)
            {
                string uname = HttpContext.Session.GetString("u"); 
                if (string.IsNullOrEmpty(uname)) 
                { ViewBag.msg = "You must be logged in to place an order.";
                    return RedirectToAction("Login"); }
                //string uname = HttpContext.Session.GetString("u");

                int qty = Convert.ToInt32(f["qty"]);


                Userorder us = new Userorder
                {
                    Username = uname,
                    Pizzaid = pid,
                    Transdate = DateOnly.FromDateTime(DateTime.Today),
                    Qty = qty
                };

                db.Userorders.Add(us);
                var res = db.SaveChanges();

                if (res > 0)
                {
                    ViewBag.msg = "Order placed successfully";
                }
                else
                {
                    ViewBag.msg = "Something went wrong";
                }
            }

           
            var resPizza = (from t in db.Pizzas where t.Pizzaid == pid select t).ToList();
            return View(resPizza);
        }



        public ViewResult Search()
        {
            return View();
        }
    
    }
}
