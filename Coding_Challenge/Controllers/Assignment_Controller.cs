using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Coding_Challenge.Models;
using Coding_Challenge.Models.AssignmentViewModels;

namespace Coding_Challenge.Controllers
{
    public class Assignment_Controller : Controller
    {
        public ActionResult list_Assignment()
        {
            List<cls_ListAssignmentViewModel> lst;
            using (Coding_ChallengeEntities db = new Coding_ChallengeEntities())
            {
                

                lst = (from Obj_Assignment in db.UserProjects
                       select new cls_ListAssignmentViewModel
                       {
                           iId = Obj_Assignment.id,
                           iUserId = Obj_Assignment.UserId,
                           iProjectId = Obj_Assignment.ProjectId,
                           bIsActive = Obj_Assignment.IsActive,
                           dtAssignedDate = Obj_Assignment.AssignedDate
                       }).ToList();
            }

            return View(lst);
        }

        public ActionResult Add_Assignment()
        {
            using (Coding_ChallengeEntities db = new Coding_ChallengeEntities())
            {
                var userInformation = new SelectList(db.Users.ToList(), "id", "FirstName");
                ViewBag.listUser = userInformation;

                var projectInformation = new SelectList(db.Projects.ToList(), "id", "id");
                ViewBag.listProject = projectInformation;
            }
                
            return View();
        }

        [HttpPost]
        public ActionResult Add_Assignment(cls_AddAssignmentViewModel model)
        {
            try
            {
                  
                using (Coding_ChallengeEntities db = new Coding_ChallengeEntities())
                {

                    var userInformation = new SelectList(db.Users.ToList(), "id", "FirstName");
                    ViewBag.listUser = userInformation;

                    var projectInformation = new SelectList(db.Projects.ToList(), "id", "id");
                    ViewBag.listProject = projectInformation;

                    if (ModelState.IsValid)
                    {
                        var Obj_Assignment = new UserProject();
                        Obj_Assignment.UserId = model.iUserId;
                        Obj_Assignment.ProjectId = model.iProjectId;
                        Obj_Assignment.IsActive = model.bIsActive == "1";
                        Obj_Assignment.AssignedDate = model.dtAssignedDate;

                        db.UserProjects.Add(Obj_Assignment);
                        db.SaveChanges();
                        return Redirect("/Assignment_/list_Assignment");
                    }
                        
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Delete_Assignment(int id)
        {
            using (Coding_ChallengeEntities db = new Coding_ChallengeEntities())
            {
                var Obj_Assignment = db.UserProjects.Find(id);
                db.UserProjects.Remove(Obj_Assignment);
                db.SaveChanges();
            }
            return Redirect("/Assignment_/list_Assignment");
        }
    }
}