using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Project.DAL;

namespace Project.Models
{
    public class Member
    {
        //a class for the member
        [Key]
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please enter at least 3 characters for the Username")]
        public string ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please enter at least 4 characters for the Password")]
        public string Phone { get; set; }
        [Required]
        public string Joined { get; set; }
        [Required]
        public int Points { get; set; }
        [Required]
        public string Expiration { get; set; }

    }
}
