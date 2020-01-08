using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.DAL;

namespace Project.Controllers
{
    public class ManagerController : Controller
    {
        private AdminDAL db = new AdminDAL();
        private MemberDAL members = new MemberDAL();
        private MenuDAL menu = new MenuDAL();
        // GET: Manager

            //action result to redirect to the manager view
        public ActionResult Manager()
        {
            if (Session["logged"] != null)
                return View("ManagerTools", MakeList());
            return View(new Manager());
        }

        //function to check the credentials are on par with the database
        public void Login(Manager obj)
        {
            if (Session["logged"] == null)
            {
                var data = db.Admins.ToList();
                for (int i = 0; i < data.Count(); i++)
                    if (data[i].Username == obj.Username && data[i].Password == obj.Password)
                        Session["logged"] = obj.Username;
            }
        }

        //public function to make a list of memebers from the database
        public DataDb MakeList()
        {
            DataDb mlist = new DataDb();
            mlist.DishList = new List<Menu>();
            mlist.MembersList = new List<Member>();
            mlist.MembersList = members.Members.ToList<Member>();
            return mlist;
        }

        //action to redirect to the manager page if the credentials are authorized
        public ActionResult ManagerTools(Manager obj)
        {
            Login(obj);
            if (Session["logged"] != null)
                return View( MakeList());
            ViewBag.ErrorMessage = "Wrong Credentials";
            return View("Manager",obj);
        }

        //action to log out of the user
        public ActionResult LogOut()
        {
            Session["logged"]=null;
            return View("Manager");
        }

        //action to add a new dish to the menu according to the form
        public ActionResult AddDish(DataDb obj)
        {
            var data = menu.Dishes.Where(x => x.Name == obj.Dish.Name).ToList<Menu>();
            if (data.Count!= 0 && data[0].Name == obj.Dish.Name)
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            Menu mem = new Menu();
            mem.Category = obj.Dish.Category;
            mem.Name = obj.Dish.Name;
            mem.Price = obj.Dish.Price;
            menu.Dishes.Add(mem);
            menu.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}