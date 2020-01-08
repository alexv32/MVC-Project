using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.DAL;
using Newtonsoft.Json;

namespace Project.Controllers
{
    public class MemberController : Controller
    {
        private MemberDAL mem = new MemberDAL();

        // GET: Member

        //the member login page action, if the member logged in already he can enter the next page.
        public ActionResult Member() 
        {
            if (Session["Memlogged"] != null)
            {
                return View("MemberPage");
            }
            return View(new Member());
        }

        //function to determine if the credentials entered are in par with the database
        public void Login(Member obj) 
        {
            if (Session["Memlogged"] == null)
            {
                var data = mem.Members.ToList();
                for (int i = 0; i < data.Count(); i++)
                    if (data[i].ID == obj.ID && data[i].Phone == obj.Phone)
                        Session["Memlogged"] = data[i].FirstName;
            }
        }

        //action result for the member login, after the check either enters the next page or not and gives error message
        public ActionResult MemberPage(Member obj) 
        {
            Login(obj);
            if (Session["Memlogged"] != null)
            {
                return View("MemberPage", obj);
            }
            ViewBag.ErrorMessage = "Wrong Credentials";
            return View("Member");
        }

        //function for the admin logout
        public ActionResult LogOut()
        {
            Session["Memlogged"]=null;
            return View("Member");
        }

        //Shows Member Data through json in the member page
        public JsonResult MemberData()
        {
            string y = Session["Memlogged"].ToString();
            List<Member> obj = mem.Members.Where(x => x.FirstName == y).ToList<Member>();
            return Json(obj,JsonRequestBehavior.AllowGet);
        }
    }
}