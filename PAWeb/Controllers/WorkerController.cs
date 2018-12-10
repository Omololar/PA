using PADomain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAWeb
{
    public class WorkerController : Controller
    {
        private IUnitOfWork _uow;
        public WorkerController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public ActionResult Views()
        {
            var dept = _uow.Departments.GetAll().Select(r => r.Name);
            ViewBag.Department = new SelectList(dept);
            return View(new WorkersViewModel());
        }
        // GET: Worker
        [HttpGet]
        public ActionResult JoinWorker()
        {
            var dept = _uow.Departments.GetAll().Select(r => r.Name);
            ViewBag.Department = new SelectList(dept);
            return View(new WorkersViewModel());
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult JoinWorker(WorkersViewModel dcvm)
        {
            if (ModelState.IsValid)
            {
                var dept = _uow.Departments.Find(r => r.Name == dcvm.DepartmentName).FirstOrDefault();
                string fileName = Path.GetFileNameWithoutExtension(dcvm.ImageFile.FileName);
                string extension = Path.GetExtension(dcvm.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                dcvm.ImageUrl = fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                dcvm.ImageFile.SaveAs(fileName);





                string file = Path.GetFileNameWithoutExtension(dcvm.FilethunmbnailUrl.FileName);
                string fileextension = Path.GetExtension(dcvm.FilethunmbnailUrl.FileName);
                file = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                dcvm.FileUrl = file;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/"), file);
                dcvm.FilethunmbnailUrl.SaveAs(file);


                var worker = new Worker
                {
                    WorkerName = dcvm.FirstName + " " + dcvm.LastName,
                    BaptismDate = dcvm.BaptismDate,
                    HolyGhostBaptism = dcvm.HolyGhostBaptism,
                    IsMarried = dcvm.IsMarried,
                    WaterBaptism = dcvm.WaterBaptism,
                    JoinDate = dcvm.JoinDate,
                    Address = dcvm.Address,
                    Department = dept,
                    ImageUrl = dcvm.ImageUrl,
                    ImageThumbnailUrl = dcvm.ImageUrl,
                    PhoneNumber = dcvm.PhoneNumber,
                    Experience = dcvm.Experience,
                    FileUrl = dcvm.FileUrl,
                    FilethunmbnailUrl = dcvm.FileUrl,
                    SpouseName = dcvm.SpouseName,
                    NumberOfChildren = dcvm.NumberOfChildren,
                    MarriageAnniversary = dcvm.MarriageAnniversary,
                    Profession = dcvm.Profession,
                    ChurchBaptised = dcvm.ChurchBaptised,
                    BornAgain = dcvm.BornAgain,
                    YearBornAgain = dcvm.YearBornAgain,
                    IsExperienced = dcvm.IsExperienced,
                    BirthDate = dcvm.BirthDate,
                    SOD = dcvm.SOD,
                    SODYear = dcvm.SODYear,
                    SOM = dcvm.SOM,
                    SOMYear = dcvm.SOMYear,
                    BC = dcvm.BC
                };

                _uow.Workers.Add(worker);

                _uow.Commit();
                TempData["message"] = string.Format("{0} has been saved.", dcvm.FirstName);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                var dept = _uow.Departments.GetAll().Select(r => r.Name);
                ViewBag.Department = new SelectList(dept);
                return View(dcvm);
            }
        }

    }
}