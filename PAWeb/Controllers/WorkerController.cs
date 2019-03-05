using PADomain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PADomain.WorkerFiles;
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

                if(dcvm.SODCert != null )
                {
                    string SODfile = Path.GetFileNameWithoutExtension(dcvm.SODCert.FileName);
                    string SODfileextension = Path.GetExtension(dcvm.SODCert.FileName);
                    SODfile = SODfile + DateTime.Now.ToString("yymmssffff") + SODfileextension;
                    dcvm.SODUrl = SODfile;
                    SODfile = Path.Combine(Server.MapPath("~/Content/Images/"), SODfile);
                    dcvm.SODCert.SaveAs(SODfile);
                }
                
                if(dcvm.BCCert != null)
                {
                    string BCfile = Path.GetFileNameWithoutExtension(dcvm.BCCert.FileName);
                    string BCfileextension = Path.GetExtension(dcvm.BCCert.FileName);
                    BCfile = BCfile + DateTime.Now.ToString("yymmssffff") + BCfileextension;
                    dcvm.BCUrl = BCfile;
                    BCfile = Path.Combine(Server.MapPath("~/Content/Images/"), BCfile);
                    dcvm.BCCert.SaveAs(BCfile);

                }
                if(dcvm.BaptismCert != null)
                {
                    string Baptismfile = Path.GetFileNameWithoutExtension(dcvm.BaptismCert.FileName);
                    string Baptismfileextension = Path.GetExtension(dcvm.BaptismCert.FileName);
                    Baptismfile = Baptismfile + DateTime.Now.ToString("yymmssffff") + Baptismfileextension;
                    dcvm.BaptismUrl = Baptismfile;
                    Baptismfile = Path.Combine(Server.MapPath("~/Content/Images/"), Baptismfile);
                    dcvm.BCCert.SaveAs(Baptismfile);
                }
             
                var worker = new Worker
                {
                    BCUrl = dcvm.BCUrl,
                    BCCert = dcvm.BCUrl,

                    BaptismUrl = dcvm.BaptismUrl,
                    BaptismCert = dcvm.BaptismUrl,
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
                    SODUrl = dcvm.SODUrl,
                    SODCert = dcvm.SODUrl,
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