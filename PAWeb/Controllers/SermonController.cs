using PADomain;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAWeb
{
    public class SermonController : Controller
    {
        IUnitOfWork _uow;
        public SermonController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public ActionResult Index()
        {
            var sermon = _uow.Sermons.GetAll();
            ViewBag.SermonCategory = _uow.SermonCategories.GetAll().Select(r => new SermonCategory
            {
                SermonName = r.SermonName,
                SermonDescription = r.SermonDescription
            });

            var sermonCat = _uow.SermonCategories.GetAll();
            var svm = new SermonViewModel
            {
                Sermons = sermon,
                SermonCategory = sermonCat,
                SermonCat = ""
            };
            return View(svm);
        }

        public ActionResult SermonsbyCategory(string name)
        {

            var sermonscategory = _uow.Sermons.Find(sc => sc.SermonCategory.SermonName == name);

            var svm = new SermonViewModel
            {
                Sermons = sermonscategory,
                //SermonCategory = name
                SermonCat = name

            };
            return View("Index", svm);
        }
        public ActionResult SermonDetails(Sermon sermon, int id)
        {

            var _sermon = _uow.Sermons.Get(id);
            var civm = new SermonIndexViewModel
            {
                sermon = _sermon
            };


            return View(civm);
        }
        public ActionResult PrintPdf(Sermon s, int id)
        {
            var _sermon = _uow.Sermons.Get(id);
            var sivm = new SermonIndexViewModel
            {
                sermon = _sermon,
                ReturnUrl = ""
            };
            var pdfView = new ViewAsPdf("SermonDetails", sivm)
            {
                FileName = sivm.sermon.Title,
                PageSize = Rotativa.Options.Size.A4,
                PageMargins =
                {
                    Left=0,
                    Right=0
                }
            };
            return pdfView;

        }


    }
}