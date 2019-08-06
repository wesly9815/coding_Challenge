using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Coding_Challenge.Models;
using Coding_Challenge.Models.ViewModels;

namespace Coding_Challenge.Controllers
{
    public class User_Controller : Controller
    {
        // GET: User_
        public ActionResult Index()
        {
            List<cls_listUserViewModel> lst;
            using (Coding_ChallengeEntities db = new Coding_ChallengeEntities())
            {
                lst = (from user in db.Users
                    select new cls_listUserViewModel
                    {
                        iId = user.id,
                        sFirtName = user.FirstName,
                        sLastName = user.LastName
                    }).ToList();
            }

            return View(lst);
        }
        
        public ActionResult Add_User()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_User(cls_AddUserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Coding_ChallengeEntities db = new Coding_ChallengeEntities())
                    {
                        var Obj_user = new User();
                        Obj_user.FirstName = model.sFirtName;
                        Obj_user.LastName = model.sLastName;

                        db.Users.Add(Obj_user);
                        db.SaveChanges();
                    }

                    return Redirect("/User_/Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Delete_User(int id)
        {
            using (Coding_ChallengeEntities db = new Coding_ChallengeEntities())
            {
                var Obj_User = db.Users.Find(id);
                db.Users.Remove(Obj_User);
                db.SaveChanges();
            }
            return Redirect("/User_/Index");
        }
    }
}