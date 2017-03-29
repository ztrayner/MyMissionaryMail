using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyMissionaryMail.Models
{
    public class Missionary
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Name")]
        public string FullName { get { return FirstName + " " + LastName; } }
        public string Sex { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Mission> Missions { get; set; }
    }
}
