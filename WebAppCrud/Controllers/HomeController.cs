using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppCrud.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var list = new List<db_user>();

            using (var db = new DBSYSEntities())
            {
                list = db.db_user.ToList();
            }

            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(db_user u) 
        {
            using (var db = new DBSYSEntities())
            {
                var newUser = new db_user();

                newUser.username = u.username;
                newUser.password = u.password;

                db.db_user.Add(newUser);
                db.SaveChanges();


                TempData["msg"] = $"Added {newUser.username} Successfully!";
            }

            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var u = new db_user();
            using (var db = new DBSYSEntities())
            {
                u = db.db_user.Find(id); 

            }
                return View(u);
        }
        [HttpPost]
        public ActionResult Update(db_user u)
        {
            using (var db = new DBSYSEntities())
            {
                var newUser = db.db_user.Find(u.id);

                newUser.username = u.username;
                newUser.password = u.password;

                
                db.SaveChanges();


                TempData["msg"] = $"Updated {newUser.username} Successfully!";
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var u = new db_user();
            using (var db = new DBSYSEntities())
            {
                u = db.db_user.Find(id);
                db.db_user.Remove(u);
                db.SaveChanges();

                TempData["msg"] = $"Deleted {u.username} Successfully!";

            }
            return RedirectToAction("Index"); 
        }
    }
}