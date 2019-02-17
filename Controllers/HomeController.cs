using StateManagmentLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateManagmentLab.Controllers
{
    public class HomeController : Controller
    {
         List<item> ItemList = new List<item>() {

           new item("Hot Chocolate", "Milk, Cocoa, Sugar", 1.99),
           new item("Latte",  "Milk, Coffee", 1.99),
           new item("Coffee",  "Coffee, Water", 1.00),
           new item("Tea", "Black Tea", 1.00),
           new item("Frozen Lemonade",  "Lemon, Sugar, Ice", 1.99),
            
       };
        List<Registration> UserList = new List<Registration>();
        List<item> ShoppingCart = new List<item>();
        public ActionResult Index()
        {
            ViewBag.CurrentUser = (Registration)Session["CurrentUser"];
            return View();
        }

        public ActionResult Print()
        {
            ViewBag.list = ItemList;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult UserDetails(Registration newUser)
        {
            //add sessions
            if (Session["CurrentUser"] != null)
            {
                newUser = (Registration)Session["CurrentUser"];
                ViewBag.CurrentUser = newUser;
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    ViewBag.CurrentUser = newUser;
                    Session["CurrentUser"] = newUser;
                    return View();
                }
                else
                {
                    ViewBag.ErrorMessage = "Registration failed. Try again.";
                    return View("Error");
                }
            }
        }

        public ActionResult LogOut()
        {
            Session.Remove("CurrentUser");
            return RedirectToAction("Index");
        }


        public ActionResult Itemlist()
        {
            ViewBag.ItemsList = ItemList;
            return View();
        }

        public ActionResult AddItem(string itemName)
        {
            if (Session["ShoppingCart"] != null)
            {
                ShoppingCart = (List<item>)Session["ShoppingCart"];
            }

            foreach (item item in ItemList)
            {              //find item in list
                if (item.ItemName == itemName)
                {
                    ShoppingCart.Add(item);
                }
            }

            Session["ShoppingCart"] = ShoppingCart;
            return RedirectToAction("ListItems");
        }
            public ActionResult WelcomeUser(Registration u)
        {
            ViewBag.CurrentUser = (Registration)Session["CurrentUser"];
            ViewBag.ItemsList = ItemList;
            return View();
           //// ViewBag.UserName = u.UserName;
           //// ViewBag.Email = u.Email;

           // return View();
        }
        public ActionResult Results(Registration u)
        {
            ViewBag.UserName = u.UserName;
            ViewBag.Email = u.Email;
            ViewBag.Age = u.Age;

            return View();


        }

    }
}