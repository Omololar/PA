using PADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAWeb
{
    public class HomeController : Controller
    {
        IUnitOfWork _uow;
        public HomeController(IUnitOfWork uow)
        {
            _uow = uow;

        }
        public ActionResult Index()
        {
            var members = _uow.Members.GetAll();
            var upcomingevent = _uow.Events.GetAll();//.GroupBy(c => c.Eventtype.Id)
            //    .Select(s => new Event() {
            //        EventDate =
            //    });
            var sermon = _uow.Sermons.GetAll();
            var news = _uow.News.GetAll();
            var gallery = _uow.Gallery.GetAll();
            var deptimg = _uow.Departments.GetAll();
            var worker = _uow.Workers.GetAll();
            var hvm = new HomeViewModel
            {
                Events = upcomingevent,
                Sermons = sermon,
                Departments = deptimg,
                Members = members,
                Pictures = gallery,
                News = news,
                Workers = worker

            };
            return View(hvm);
        }

        public ActionResult About()
        {
            var departmentleaders = _uow.Departments.GetAll();
            var dvm = new DeptViewModel
            {
                Departments = departmentleaders
            };
            return View(dvm); ;
        }


        public ActionResult Contact()
        {

            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult GetContactMessage(ContactModel cm)
        {
            if (ModelState.IsValid)
            {
                var contact = new Contact
                {
                    FromEmail = cm.FromEmail,
                    Subject = cm.Subject,
                    FullName = cm.FullName,
                    PhoneNumber = cm.PhoneNumber,
                    Body = cm.Body,
                    To = "praiseassembly@gmail.com"
                };
                _uow.Contact.Add(contact);
                _uow.Commit();
                TempData["message"] = string.Format("your message was sent successfully to {0} ", cm.To);
                ViewBag.Message = "Message Sent Successfully";
                return RedirectToAction("Index", "Home");
            }

            return View(cm);
        }
        public ActionResult NationalProgramme()
        {


            var upcomingevent = _uow.Events.GetAll();

            var dvm = new HomeViewModel
            {

                Events = upcomingevent

            };
            return View(dvm);

        }

    }
}