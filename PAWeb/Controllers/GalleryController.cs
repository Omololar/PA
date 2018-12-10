using PADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAWeb
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        IUnitOfWork _uow;
        public GalleryController(IUnitOfWork uow)
        {
            _uow = uow;

        }
        public ActionResult Gallery()
        {
            var gallery = _uow.Gallery.GetAll();
            var hvm = new HomeViewModel
            {
                Pictures = gallery,
            };
            return View(hvm);

        }
    }
}