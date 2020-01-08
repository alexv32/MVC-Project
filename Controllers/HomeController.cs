using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using Project.DAL;
using Newtonsoft.Json;


namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private MemberDAL members = new MemberDAL();
        private MenuDAL MenuDishes = new MenuDAL();
        
        public ActionResult Index()
        {
            return View();
        }
        
        //shows the menu page
        public ActionResult Menu()
        {
            return View();
        }
        
        //json functions for the menu properties, one for each category
        public JsonResult StarterData()
        {
            List<Menu> start = MenuDishes.Dishes.Where(x => x.Category == "Starter").ToList<Menu>();
            return Json(start,JsonRequestBehavior.AllowGet);
        }
        public JsonResult MainData()
        {
            List<Menu> main = MenuDishes.Dishes.Where(x => x.Category == "Main").ToList<Menu>();
            return Json(main, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DessertData()
        {
            List<Menu> dessert = MenuDishes.Dishes.Where(x => x.Category == "Dessert").ToList<Menu>();
            return Json(dessert, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DrinkData()
        {
            List<Menu> drink = MenuDishes.Dishes.Where(x => x.Category == "Drink").ToList<Menu>();
            return Json(drink, JsonRequestBehavior.AllowGet);
        }

        //redirection to the register page
        public ActionResult Register()
        {
            return View(new Member());
        }

        //action result for submiting a new registered user
        public ActionResult Submit(Member obj)
        {
            
            var data = members.Members.Where(x => x.ID == obj.ID).ToList<Member>();
            if (data.Count!=0 && data[0].ID == obj.ID)
            {
                return Json(new { success = false },JsonRequestBehavior.AllowGet);
            }
            Member mem = new Member();
            mem.ID = obj.ID;
            mem.FirstName = obj.FirstName;
            mem.LastName = obj.LastName;
            mem.Phone = obj.Phone;
            mem.Joined = System.DateTime.Today.Day.ToString()+"/"+System.DateTime.Today.Month.ToString()+ "/"+ System.DateTime.Today.Year.ToString(); 
            mem.Points = 0;
            mem.Expiration = System.DateTime.Today.Day.ToString() + "/" + System.DateTime.Today.Month.ToString() + "/" + (System.DateTime.Today.Year+1).ToString();
            members.Members.Add(mem);
            members.SaveChanges();
            
            return Json(new{success = true},JsonRequestBehavior.AllowGet);
        }
    }
}