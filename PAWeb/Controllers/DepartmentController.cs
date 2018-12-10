using PADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAWeb
{
    public class DepartmentController : Controller
    {
        private IUnitOfWork _uow;
        public DepartmentController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Department
        [HttpGet]
        public ActionResult DepartmentCorner()
        {
            var currentdepartment = _uow.Departments.GetAll();

            var dvm = new DeptListViewModel
            {

                AllDepartment = currentdepartment

            };
            return View(dvm);
        }

    }
}