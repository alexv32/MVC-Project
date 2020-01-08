using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Project.DAL;

namespace Project.Models
{
    public class Manager
    {
        //a class for the admin 
        [Key]
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please enter at least 3 characters for the Username")]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Please enter at least 4 characters for the Password")]
        public string Password { get; set; }
    }
}
