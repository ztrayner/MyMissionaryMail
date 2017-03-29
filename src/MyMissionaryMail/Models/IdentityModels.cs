using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Framework.OptionsModel;
using MyMissionaryMail.Models;
using MyMissionaryMail.DAL;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMissionaryMail.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("Missionary")]
        public int? MissionaryId { get; set; }
        public Missionary missionary { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
    }


}
