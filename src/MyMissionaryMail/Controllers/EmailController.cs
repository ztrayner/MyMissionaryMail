using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MyMissionaryMail.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyMissionaryMail.Models;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyMissionaryMail.Controllers
{
    public class EmailController : Controller
    {
        private MyMissionaryMailContext db = new MyMissionaryMailContext();

        public RoleManager<IdentityRole> RoleManager { get; private set; }

        //private UserManager<ApplicationUser> UserManager;
        //public UserManager<ApplicationUser> UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}

        // GET: EmailUploads
        public ActionResult Index()
        {
            var userId = User.GetUserId();

            //ApplicationUser currentUser = UserManager.FindByIdAsync(userId).Result;
            //ApplicationUser thisUser = db.Users.Where(u => u.Id == userId).SingleOrDefault();
            //var allMissionaries = currentUser.Missionaries.ToList();
            //List<List<Email>> allEmails = new List<List<Email>>();
            //foreach (ApplicationUser missionary in allMissionaries)
            //{
            //    var email = missionary.Emails.ToList();
            //    allEmails.Add(email);
            //};
            //MyMissionaryEmailsVM ViewModel = new MyMissionaryEmailsVM
            //{
            //    Missionaries = allMissionaries,
            //    EmailUploads = allEmails
            //};


            return View();
        }

        public ActionResult Admin()
        {
            return View(db.Emails.ToList());
        }

        // GET: EmailUploads/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    EmailUpload emailUpload = db.EmailUploads.Find(id);
        //    if (emailUpload == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(emailUpload);
        //}

        // GET: EmailUploads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmailUploads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "id,FromEmail,RecipientEmail,Subject,BodyPlain,StrippedText,StrippedSignature,BodyHtml,StrippedHtml,AttachmentCount,TimeStampSeconds,TimeStamp")] EmailUpload emailUpload)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.EmailUploads.Add(emailUpload);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(emailUpload);
        //}

        //// POST: /EmailUploads/Post
        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult Post(FormCollection form)
        //{
        //    try
        //    {
        //        EmailUpload email = new EmailUpload();
        //        email.FromEmail = Request.Unvalidated.Form["sender"];
        //        email.RecipientEmail = Request.Unvalidated.Form["recipient"];
        //        email.Subject = Request.Unvalidated.Form["subject"];
        //        email.BodyPlain = Request.Unvalidated.Form["body-plain"];
        //        email.StrippedText = Request.Unvalidated.Form["stripped-text"];
        //        email.StrippedSignature = Request.Unvalidated.Form["stripped-signature"];
        //        email.BodyHtml = Request.Unvalidated.Form["body-html"];
        //        email.StrippedHtml = Request.Unvalidated.Form["stripped-html"];
        //        email.AttachmentCount = Convert.ToInt32(Request.Unvalidated.Form["attachment-count"]);
        //        email.TimeStampSeconds = Convert.ToInt64(Request.Unvalidated.Form["timestamp"]);
        //        email.TimeStamp = FromUnixTime(email.TimeStampSeconds);

        //        // Work your magic
        //        db.EmailUploads.Add(email);
        //        db.SaveChanges();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return Content("ok");
        //}


        private static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return epoch.AddSeconds(unixTime);
        }

        // GET: EmailUploads/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    EmailUpload emailUpload = db.EmailUploads.Find(id);
        //    if (emailUpload == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(emailUpload);
        //}

        // POST: EmailUploads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "id,FromEmail,RecipientEmail,Subject,BodyPlain,StrippedText,StrippedSignature,BodyHtml,StrippedHtml,AttachmentCount,TimeStampSeconds,TimeStamp")] EmailUpload emailUpload)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(emailUpload).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(emailUpload);
        //}

        //// GET: EmailUploads/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    EmailUpload emailUpload = db.EmailUploads.Find(id);
        //    if (emailUpload == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(emailUpload);
        //}

        // POST: EmailUploads/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    EmailUpload emailUpload = db.EmailUploads.Find(id);
        //    db.EmailUploads.Remove(emailUpload);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
