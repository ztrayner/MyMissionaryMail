using MyMissionaryMail.DAL;
using System;
using Microsoft.Framework.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using MyMissionaryMail.Models;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace MyMissionaryMail.Migrations
{
    public class SampleData
    {
        private MyMissionaryMailContext db;
        private UserManager<ApplicationUser> userManager;
        private readonly string AdminEmail = "ztrayner@gmail.com";

        public SampleData(MyMissionaryMailContext context, UserManager<ApplicationUser> UserManager)
        {
            db = context;
            userManager = UserManager;
        }
        public void Initialize()
        {
            CreateEmails();
            CreateUsers().Wait();
            CreateMissionaries();
            CreateMissions();
            MakeAssociations();
        }
        private async Task CreateUsers()
        {
            try
            {
                var user = await userManager.FindByEmailAsync(AdminEmail);
                if (user == null)
                {
                    user = new ApplicationUser() { UserName = "missionary", Email = AdminEmail };
                    await userManager.CreateAsync(user, "P@ssw0rd!");

                    user = new ApplicationUser() { UserName = "parent", Email = "me@zachtrayner.com" };
                    await userManager.CreateAsync(user, "P@ssw0rd!");

                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }

        }
        private void CreateEmails()
        {
            if (db.Emails.Count() == 0)
            {
                db.Emails.AddRange(
                        new Email
                        {
                            AttachmentCount = 0,
                            BodyHtml = "Hey Everyone,</br>I love the mission so much!",
                            BodyPlain = "Hey Everyone, I love the mission so much!",
                            FromEmail = AdminEmail,
                            RecipientEmail = "me@zachtrayner.com",
                            StrippedHtml = "Hey Everyone, I love the mission so much!",
                            StrippedSignature = "Elder Trayner",
                            StrippedText = "Hey Everyone, I love the mission so much!",
                            Subject = "The Mission: Part I",
                            TimeStamp = DateTime.Now,
                            TimeStampSeconds = DateTime.Now.Second
                        },
                        new Email
                        {
                            AttachmentCount = 0,
                            BodyHtml = "Hey Elder,<br/>Sorry to hear that.  Keep your head up.",
                            BodyPlain = "Hey Elder,  Sorry to hear that.  Keep your head up.",
                            FromEmail = "me@zachtrayner.com",
                            RecipientEmail = AdminEmail,
                            StrippedHtml = "Hey Elder,  Sorry to hear that.  Keep your head up.",
                            StrippedSignature = "Father Trayner",
                            StrippedText = "Hey Elder,  Sorry to hear that.  Keep your head up.",
                            Subject = "The Mission: Part I Reply",
                            TimeStamp = DateTime.Now.AddSeconds(2),
                            TimeStampSeconds = DateTime.Now.AddSeconds(2).Second
                        }
                    );
                db.SaveChanges();
            }
        }
        private void CreateMissionaries()
        {
            db.Missionaries.AddRange(
                new Missionary
                {
                    Email = AdminEmail,
                    FirstName = "Missionary",
                    LastName = "Trayner",
                    Missions = null,
                    Sex = "Male"
                }
            );
            db.SaveChanges();
            var missionaryUser = db.Users.Where(u => u.UserName.Contains("missionary")).SingleOrDefault();
            missionaryUser.MissionaryId = 1;
            db.SaveChanges();
        }
        private void CreateMissions()
        {
            db.Missions.AddRange(
                new Mission
                {
                    AssignedUsers = new List<ApplicationUser>() { db.Users.Where(u => u.Email == AdminEmail).SingleOrDefault() },
                    Emails = db.Emails.ToList(),
                    EndDate = DateTime.Today.AddYears(2),
                    MissionaryId = db.Missionaries.Where(m => m.Email == AdminEmail).SingleOrDefault().Id,
                    MissionName = "Argentina Buenos Aires North",
                    MissionPresidents = new List<string>() { "Richard Gulbrandsen" },
                    StartDate = DateTime.Today
                }
            );
            db.SaveChanges();

        }
        private void MakeAssociations()
        {
            var missionaryToEdit = db.Missionaries.Where(m => m.Email == AdminEmail).SingleOrDefault();
            missionaryToEdit.Missions = db.Missions.Where(m => m.Id == 1).ToList();
            var missionToEdit = db.Missions.SingleOrDefault();
            missionToEdit.AssignedUsers = db.Users.ToList();
            var emailToEdit = db.Emails.Where(e => e.Id == 1).SingleOrDefault();
            emailToEdit.MissionaryId = 1;
            var secondEmailToEdit = db.Emails.Where(e => e.Id == 2).SingleOrDefault();
            secondEmailToEdit.UserId = db.Users.Where(u => u.UserName == "parent").SingleOrDefault().Id;
            db.SaveChanges();
        }



    }
}
