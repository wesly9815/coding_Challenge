using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Coding_Challenge.Models;
using Coding_Challenge.Models.ProjectViewModels;

namespace Coding_Challenge.Controllers
{
    public class Project_Controller : Controller
    {
        // Get: Project

        public ActionResult list_Project()
        {
            List<cls_ListProjectViewModel> lst;
            using (Coding_ChallengeEntities db = new Coding_ChallengeEntities())
            {
                lst = (from Obj_project in db.Projects
                       select new cls_ListProjectViewModel
                       {
                           iId = Obj_project.id,
                           dtStartDate = Obj_project.StartDate,
                           dtEndData = Obj_project.EndDate,
                           iCredits = Obj_project.Credits
                       }).ToList();
            }

            return View(lst);
        }

        public ActionResult Add_Project()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_Project(cls_AddProjectViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Coding_ChallengeEntities db = new Coding_ChallengeEntities())
                    {
                        var Obj_project = new Project();
                        Obj_project.StartDate = model.dtStartDate;
                        Obj_project.EndDate = model.dtEndData;
                        Obj_project.Credits = model.iCredits;


                        db.Projects.Add(Obj_project);
                        db.SaveChanges();
                    }

                    return Redirect("/Project_/list_Project");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Delete_Project(int id)
        {
            using (Coding_ChallengeEntities db = new Coding_ChallengeEntities())
            {
                var Obj_Project = db.Projects.Find(id);
                db.Projects.Remove(Obj_Project);
                db.SaveChanges();
            }
            return Redirect("/Project_/list_Project");
        }
    }
}