using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyMissionaryMail.Models
{
    public class Mission
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string MissionName { get; set; }
        public List<string> MissionPresidents { get; set; }

        [ForeignKey("Missionary")]
        public int MissionaryId { get; set; }
        public Missionary Missionary { get; set; }
        public virtual ICollection<ApplicationUser> AssignedUsers { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
    }
}
