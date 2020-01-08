using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;

namespace Project.Models
{
    public class DataDb
    {
        //a helper model for working with more than one model in view
        public Member member { get; set; }
        public Menu Dish { get; set; }
        public List<Member> MembersList { get; set;}
        public List<Menu>   DishList { get; set; }
        public string Status {
            get
            {
                if (MembersList.Count > 0)
                    return "block";
                else
                    return "none";
            }
         }
    }
}