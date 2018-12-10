using PADomain;
using PALogic;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAWeb
{
    [Authorize]
    public class AdminController : Controller
    {
        private IUnitOfWork _uow;

        //private readonly IUserRepo<User> _userRepo;
        public AdminController(IUnitOfWork uow)
        {
            _uow = uow;


        }

        public ActionResult Index()
        {
            ViewBag.DepartmentCount = _uow.Departments.GetAll().Count();
            ViewBag.EventCount = _uow.Events.GetAll().Count();
            ViewBag.SermonCount = _uow.Sermons.GetAll().Count();
            ViewBag.WorkerCount = _uow.Workers.GetAll().Count();
            ViewBag.MemberCount = _uow.Members.GetAll().Count();
            @ViewBag.CountMails = _uow.Contact.GetAll().Count();
            return View();
        }

        [HttpGet]
        public ActionResult AddAnnouncement()
        {
            var member = _uow.News.GetAll().Select(r => r.Name);

            return View(new NewsViewModel());
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddAnnouncement(NewsViewModel gvm)
        {
            if (ModelState.IsValid)
            {
                var member = _uow.News.Find(r => r.Name == gvm.Name).FirstOrDefault();

                string fileName = Path.GetFileNameWithoutExtension(gvm.PictureThumbnailUrl.FileName);
                string extension = Path.GetExtension(gvm.PictureThumbnailUrl.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                gvm.PictureUrl = fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);

                gvm.PictureThumbnailUrl.SaveAs(fileName);

                var _news = new News
                {
                    Name = gvm.Name,
                    DueDate = gvm.Date,
                    PictureUrl = gvm.PictureUrl,
                    PictureThumbnailUrl = gvm.PictureUrl,
                    Description = gvm.Description,
                    Venue = gvm.Venue

                };

                _uow.News.Add(_news);
                _uow.Commit();
                TempData["message"] = string.Format("{0} has been saved.", gvm.Name);
                return RedirectToAction("Index");

            }
            else
            {
                var member = _uow.Members.GetAll().Select(r => r.MemberName);

                return View(gvm);
            }
        }

        public ActionResult DeleteAnnouncement(int Id)
        {
            var news = _uow.News.Find(s => s.Id == Id).FirstOrDefault();
            if (news.PictureUrl != null)
            {
                var filepath = Server.MapPath(@"~/Content/Images");
                List<string> files = Directory.GetFiles(filepath).ToList();
                var fullpath = string.Empty;
                string filename = news.PictureThumbnailUrl;
                string realfilename = files.Where(i => i.Contains(filename)).FirstOrDefault();
                if (realfilename != null)
                {
                    fullpath = Path.Combine(Server.MapPath("~/Content/Images/"), realfilename);
                    if (System.IO.File.Exists(fullpath))
                    {
                        System.IO.File.Delete(fullpath);
                        var ImgMessage = $"the image:{fullpath} was also removed";
                    }
                }
            }
            if (news != null)
            {

                _uow.News.Remove(news);
                _uow.Commit();
                TempData["message"] = $"{news.Name} was successfully deleted.{Environment.NewLine}";
            }
            return RedirectToAction("WorkerList");
        }
        [HttpGet]
        public ActionResult NewsList(int? page)
        {
            var pageSize = 10;
            var news = _uow.News.GetAll().ToList().ToPagedList(page ?? 1, pageSize);
            var mlvm = new NewsListViewModel
            {
                News = news
            };
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            return View(mlvm);
        }
        [HttpGet]
        public ActionResult EditNews(int id)
        {
            var news = _uow.News.Get(id);

            var wvm = new NewsViewModel
            {
                Name = news.Name,
                Date = news.DueDate,
                Description = news.Description,
                Venue = news.Venue,
                PictureUrl = news.PictureUrl
            };
            return View(wvm);

        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditNews(NewsViewModel wvm)
        {
            if (ModelState.IsValid)
            {
                var news = _uow.News.Get(wvm.Id);

                if (news != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(wvm.PictureThumbnailUrl.FileName);
                    string extension = Path.GetExtension(wvm.PictureThumbnailUrl.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                    wvm.PictureUrl = fileName;
                    fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);

                    news.Name = wvm.Name;
                    news.DueDate = wvm.Date;
                    news.Description = wvm.Description;
                    news.PictureUrl = wvm.PictureUrl;
                    news.Venue = wvm.Venue;
                    news.PictureThumbnailUrl = wvm.PictureUrl;
                    if (wvm.PictureThumbnailUrl != null && wvm.PictureThumbnailUrl.ContentLength > 0)
                    {
                        wvm.PictureThumbnailUrl.SaveAs(fileName);
                    }

                    _uow.Commit();
                    TempData["message"] = $"{news.Name} was successfully edited ";
                }
                return RedirectToAction("Index");

            }
            else
            {
                return View(wvm);
            }
        }

        [HttpGet]
        public ActionResult Gallery()
        {
            var member = _uow.Gallery.GetAll().Select(r => r.Name);

            return View(new GalleryViewModel());
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Gallery(GalleryViewModel gvm)
        {
            if (ModelState.IsValid)
            {
                var member = _uow.Gallery.Find(r => r.Name == gvm.Name).FirstOrDefault();

                string fileName = Path.GetFileNameWithoutExtension(gvm.PictureThumbnailUrl.FileName);
                string extension = Path.GetExtension(gvm.PictureThumbnailUrl.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                gvm.PictureUrl = fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);

                gvm.PictureThumbnailUrl.SaveAs(fileName);

                var _picture = new Gallery
                {
                    Name = gvm.Name,
                    EventDate = gvm.Date,
                    PictureUrl = gvm.PictureUrl,
                    PictureThumbnailUrl = gvm.PictureUrl,
                    PictureDescription = gvm.Description

                };

                _uow.Gallery.Add(_picture);
                _uow.Commit();
                TempData["message"] = string.Format("{0} has been saved.", gvm.Name);
                return RedirectToAction("Index");

            }
            else
            {
                var member = _uow.Members.GetAll().Select(r => r.MemberName);

                return View(gvm);
            }
        }

        [HttpGet]
        public ActionResult PictureList(int? page)
        {
            var pageSize = 10;
            var pictures = _uow.Gallery.GetAll().ToList().ToPagedList(page ?? 1, pageSize);
            var mlvm = new GalleryListViewModel
            {
                Pictures = pictures
            };
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            return View(mlvm);
        }

        [HttpGet]
        public ActionResult Member()
        {
            var member = _uow.Members.GetAll().Select(r => r.MemberName);

            return View(new MembersViewModel());
        }
        [HttpPost]
        public ActionResult Member(MembersViewModel mvm)
        {
            if (ModelState.IsValid)
            {
                var member = _uow.Members.Find(r => r.MemberName == mvm.LastName).FirstOrDefault();

                string fileName = Path.GetFileNameWithoutExtension(mvm.MemeberImageThumbnailUrl.FileName);
                string extension = Path.GetExtension(mvm.MemeberImageThumbnailUrl.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                mvm.MemberImageUrl = fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);

                mvm.MemeberImageThumbnailUrl.SaveAs(fileName);

                var _member = new Member
                {
                    MemberName = mvm.FirstName + " " + mvm.OtherName + " " + mvm.LastName,
                    Address = mvm.Address,
                    Profession = mvm.Profession,
                    SpouseName = mvm.SpouseName,
                    DateOfBirth = mvm.DateOfBirth,
                    MemberImageUrl = mvm.MemberImageUrl,
                    MemeberImageThumbnailUrl = mvm.MemberImageUrl,
                    WeddingAnniversary = mvm.WeddingAnniversary,
                    PhoneNumber = mvm.PhoneNumber,
                    Married = mvm.Married
                };

                _uow.Members.Add(_member);
                _uow.Commit();
                TempData["message"] = string.Format("{0} has been saved.", mvm.FirstName);
                return RedirectToAction("Index");

            }
            else
            {
                var member = _uow.Members.GetAll().Select(r => r.MemberName);

                return View(mvm);
            }
        }

        [HttpGet]
        public ActionResult MemberList(int? page)
        {
            var pageSize = 10;
            var members = _uow.Members.GetAll().ToList().ToPagedList(page ?? 1, pageSize);
            var mlvm = new MemberListViewModel
            {
                Members = members
            };
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            return View(mlvm);
        }

        public ActionResult DeleteMember(int Id)
        {
            var member = _uow.Members.Find(s => s.Id == Id).FirstOrDefault();
            if (member.MemberImageUrl != null)
            {
                var filepath = Server.MapPath(@"~/Content/Images");
                List<string> files = Directory.GetFiles(filepath).ToList();
                var fullpath = string.Empty;
                string filename = member.MemberImageUrl;
                string realfilename = files.Where(i => i.Contains(filename)).FirstOrDefault();
                if (realfilename != null)
                {
                    fullpath = Path.Combine(Server.MapPath("~/Content/Images/"), realfilename);
                    if (System.IO.File.Exists(fullpath))
                    {
                        System.IO.File.Delete(fullpath);
                        var ImgMessage = $"the image:{fullpath} was also removed";
                    }
                }
            }
            if (member != null)
            {

                _uow.Members.Remove(member);
                _uow.Commit();
                TempData["message"] = $"{member.MemberName} was successfully deleted.{Environment.NewLine}";
            }
            return RedirectToAction("WorkerList");
        }
        [HttpGet]
        public ActionResult EditMember(int id)
        {
            var member = _uow.Members.Get(id);
            var wvm = new MembersViewModel
            {
                FirstName = member.MemberName,
                Address = member.Address,
                Profession = member.Profession,
                PhoneNumber = member.PhoneNumber,
                MemberImageUrl = member.MemberImageUrl
            };
            return View(wvm);

        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditMember(MembersViewModel wvm)
        {
            if (ModelState.IsValid)
            {
                var member = _uow.Members.Get(wvm.Id);

                if (member != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(wvm.MemeberImageThumbnailUrl.FileName);
                    string extension = Path.GetExtension(wvm.MemeberImageThumbnailUrl.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                    wvm.MemberImageUrl = fileName;
                    fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);

                    member.MemberName = wvm.FirstName + "" + wvm.LastName + "" + wvm.OtherName;
                    member.PhoneNumber = wvm.PhoneNumber;
                    member.Address = wvm.Address;
                    member.MemberImageUrl = wvm.MemberImageUrl;
                    member.MemeberImageThumbnailUrl = wvm.MemberImageUrl;
                    if (wvm.MemeberImageThumbnailUrl != null && wvm.MemeberImageThumbnailUrl.ContentLength > 0)
                    {
                        wvm.MemeberImageThumbnailUrl.SaveAs(fileName);
                    }


                    _uow.Commit();
                    TempData["message"] = $"{member.MemberName} was successfully edited ";
                }
                return RedirectToAction("Index");

            }
            else
            {
                return View(wvm);
            }
        }
        public ActionResult DeleteMail(int Id)
        {
            var _mail = _uow.Contact.Find(e => e.Id == Id).FirstOrDefault();
            if (_mail != null)
            {
                _uow.Contact.Remove(_mail);
                _uow.Commit();
                TempData["message"] = $"{_mail.Subject} was successfully deleted.{Environment.NewLine}";
            }
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult AddSermon()
        {
            var sermoncategory = _uow.SermonCategories.GetAll().Select(r => r.SermonName);
            ViewBag.SermonCategory = new SelectList(sermoncategory);

            return View(new SermonView());
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddSermon(SermonView sv)
        {
            if (ModelState.IsValid)
            {
                var sermoncat = _uow.SermonCategories.Find(s => s.SermonName == sv.SermonCategoryName).FirstOrDefault();
                string fileName = Path.GetFileNameWithoutExtension(sv.ImageFile.FileName);
                string extension = Path.GetExtension(sv.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                sv.ImageUrl = fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                sv.ImageFile.SaveAs(fileName);





                var addsermon = new Sermon
                {
                    SermonDate = sv.SermonDate,
                    Title = sv.SermonTitle,
                    Bibletext = sv.SermonText,
                    PreacherName = sv.PreacherName,
                    LongDescription = sv.LongDescription,
                    ShortDescription = sv.ShortDescription,
                    SermonCategory = sermoncat,
                    ImageUrl = sv.ImageUrl,
                    ImageThumbnailUrl = sv.ImageUrl,
            


                };
                _uow.Sermons.Add(addsermon);
                _uow.Commit();
                TempData["message"] = string.Format("{0} has been saved.", sv.SermonTitle);
                return RedirectToAction("SermonList");
            }
            else
            {
                var sermoncategory = _uow.SermonCategories.GetAll().Select(r => r.SermonName);
                ViewBag.SermonCategory = new SelectList(sermoncategory);
                return View(sv);
            }
        }


        [HttpGet]
        public ActionResult AllContactMessag(int? page)
        {
            var pageSize = 10;
            var messages = _uow.Contact.GetAll().ToList().ToPagedList(page ?? 1, pageSize);
            var mlvm = new ContactListModel
            {
                Contacts = messages
            };
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            return View(mlvm);
        }

        [HttpGet]
        public ActionResult AddEvent()
        {
            var eventtype = _uow.Eventtype.GetAll().Select(r => r.Name);
            // var events = _uow.Events.GetAll().Select(r => r.EventName);

            ViewBag.Events = new SelectList(eventtype);
            return View(new EventViewModel());
        }


        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddEvent(EventViewModel evm)
        {
            if (ModelState.IsValid)
            {
                var eventtype = _uow.Eventtype.Find(r => r.Name == evm.EventType).FirstOrDefault();
                //var events = _uow.Events.Find(r => r.EventName == evm.EventName).FirstOrDefault();
                string fileName = Path.GetFileNameWithoutExtension(evm.EventImageFile.FileName);
                string extension = Path.GetExtension(evm.EventImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                evm.EventImageUrl = fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                evm.EventImageFile.SaveAs(fileName);
                var addevent = new Event
                {
                    EventDate = evm.EventDate,
                    EventName = evm.EventName,
                    EventTheme = evm.EventTheme,
                    EventDescription = evm.EventDescription,
                    EventImageUrl = evm.EventImageUrl,
                    EventLocation = evm.EventLocation,
                    EventImageThumbnailUrl = evm.EventImageUrl,
                    Eventtype = eventtype
                };
                _uow.Events.Add(addevent);
                _uow.Commit();
                TempData["message"] = string.Format("{0} has been saved.", evm.EventName);
                return RedirectToAction("EventList");
            }
            else
            {
                var eventtype = _uow.Eventtype.GetAll().Select(r => r.Name);
                ViewBag.Events = new SelectList(eventtype);
                return View(evm);
            }
        }

        [HttpGet]
        public ActionResult EditSermon(int id)
        {
            var _sermon = _uow.Sermons.Get(id);
            var sermoncategories = _uow.SermonCategories.GetAll();
            var sermoncat = _sermon.SermonCategory;
            ViewBag.SermonCategory = new SelectList(sermoncategories, "SermonName", "SermonName", sermoncat.SermonName);

            var svm = new SermonView
            {
                LongDescription = _sermon.LongDescription,
                ShortDescription = _sermon.ShortDescription,
                PreacherName = _sermon.PreacherName,
                SermonCategoryName = _sermon.SermonCategory.SermonName,
                SermonDate = _sermon.SermonDate,
                SermonText = _sermon.Bibletext,
                SermonTitle = _sermon.Title,
                //Id = _sermon.Id,
                ImageUrl = _sermon.ImageUrl,
              

            };
            return View(svm);
        }


        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditSermon(SermonView svm)
        {
            if (ModelState.IsValid)
            {
                var sermon = _uow.Sermons.Get(svm.Id);
                var sermoncat = _uow.SermonCategories.Find(s => s.SermonName == svm.SermonCategoryName).FirstOrDefault();
                if (sermon != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(svm.ImageFile.FileName);
                    string extension = Path.GetExtension(svm.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                    svm.ImageUrl = fileName;
                    fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);

                    sermon.Bibletext = svm.SermonText;
                    sermon.Title = svm.SermonTitle;
                    sermon.SermonDate = svm.SermonDate;
                    sermon.PreacherName = svm.PreacherName;
                    sermon.LongDescription = svm.LongDescription;
                    sermon.ShortDescription = svm.ShortDescription;
                    sermon.ImageUrl = svm.ImageUrl;
                    sermon.ImageThumbnailUrl = svm.ImageUrl;
                   
                    sermon.SermonCategory = sermoncat;

                    _uow.Commit();
                    TempData["message"] = $"{sermon.Title} was successfully edited ";
                }
                return RedirectToAction("SermonList");

            }
            else
            {
                return View(svm);
            }
        }
        [HttpGet]
        public ActionResult EditWorker(int id)
        {
            var worker = _uow.Workers.Get(id);
            var dept = _uow.Departments.GetAll();
            var dep = worker.Department;
            ViewBag.workerdept = new SelectList(dept, "Name", "Name", dep.Name);
            var wvm = new WorkersViewModel
            {
                FirstName = worker.WorkerName,
                Address = worker.Address,
                DepartmentName = worker.Department.Name,
                PhoneNumber = worker.PhoneNumber,
                ImageUrl = worker.ImageUrl
            };
            return View(wvm);

        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditWorker(WorkersViewModel wvm)
        {
            if (ModelState.IsValid)
            {
                var worker = _uow.Workers.Get(wvm.Id);
                var dept = _uow.Departments.Find(s => s.Name == wvm.DepartmentName).FirstOrDefault();
                if (worker != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(wvm.ImageFile.FileName);
                    string extension = Path.GetExtension(wvm.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                    wvm.ImageUrl = fileName;
                    fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);

                    worker.WorkerName = wvm.FirstName + "" + wvm.LastName + "" + wvm.OtherName;
                    worker.PhoneNumber = wvm.PhoneNumber;
                    worker.Address = wvm.Address;
                    worker.ImageUrl = wvm.ImageUrl;
                    worker.ImageThumbnailUrl = wvm.ImageUrl;
                    if (wvm.ImageFile != null && wvm.ImageFile.ContentLength > 0)
                    {
                        wvm.ImageFile.SaveAs(fileName);
                    }
                    worker.Department = dept;

                    _uow.Commit();
                    TempData["message"] = $"{worker.WorkerName} was successfully edited ";
                }
                return RedirectToAction("Index");

            }
            else
            {
                return View(wvm);
            }
        }


        [HttpGet]
        public ActionResult EditPicture(int id)
        {
            var picture = _uow.Gallery.Get(id);

            var wvm = new GalleryViewModel
            {
                Name = picture.Name,
                Date = picture.EventDate,
                Description = picture.PictureDescription,

                PictureUrl = picture.PictureUrl
            };
            return View(wvm);

        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditPicture(GalleryViewModel wvm)
        {
            if (ModelState.IsValid)
            {
                var picture = _uow.Gallery.Get(wvm.Id);
                var dept = _uow.Gallery.Find(s => s.Name == wvm.Name).FirstOrDefault();
                if (picture != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(wvm.PictureThumbnailUrl.FileName);
                    string extension = Path.GetExtension(wvm.PictureThumbnailUrl.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                    wvm.PictureUrl = fileName;
                    fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);

                    picture.Name = wvm.Name;
                    picture.EventDate = wvm.Date;
                    picture.PictureDescription = wvm.Description;
                    picture.PictureUrl = wvm.PictureUrl;
                    picture.PictureThumbnailUrl = wvm.PictureUrl;
                    if (wvm.PictureThumbnailUrl != null && wvm.PictureThumbnailUrl.ContentLength > 0)
                    {
                        wvm.PictureThumbnailUrl.SaveAs(fileName);
                    }

                    _uow.Commit();
                    TempData["message"] = $"{picture.Name} was successfully edited ";
                }
                return RedirectToAction("Index");

            }
            else
            {
                return View(wvm);
            }
        }

        public ActionResult DeletePicture(int Id)
        {
            var worker = _uow.Gallery.Find(s => s.Id == Id).FirstOrDefault();
            if (worker.PictureThumbnailUrl != null)
            {
                var filepath = Server.MapPath(@"~/Content/Images");
                List<string> files = Directory.GetFiles(filepath).ToList();
                var fullpath = string.Empty;
                string filename = worker.PictureUrl;
                string realfilename = files.Where(i => i.Contains(filename)).FirstOrDefault();
                if (realfilename != null)
                {
                    fullpath = Path.Combine(Server.MapPath("~/Content/Images/"), realfilename);
                    if (System.IO.File.Exists(fullpath))
                    {
                        System.IO.File.Delete(fullpath);
                        var ImgMessage = $"the image:{fullpath} was also removed";
                    }
                }
            }
            if (worker != null)
            {

                _uow.Gallery.Remove(worker);
                _uow.Commit();
                TempData["message"] = $"{worker.Name} was successfully deleted.{Environment.NewLine}";
            }
            return RedirectToAction("WorkerList");
        }


        public ActionResult DeleteWorker(int Id)
        {
            var worker = _uow.Workers.Find(s => s.Id == Id).FirstOrDefault();
            if (worker.ImageUrl != null)
            {
                var filepath = Server.MapPath(@"~/Content/Images");
                List<string> files = Directory.GetFiles(filepath).ToList();
                var fullpath = string.Empty;
                string filename = worker.ImageUrl;
                string realfilename = files.Where(i => i.Contains(filename)).FirstOrDefault();
                if (realfilename != null)
                {
                    fullpath = Path.Combine(Server.MapPath("~/Content/Images/"), realfilename);
                    if (System.IO.File.Exists(fullpath))
                    {
                        System.IO.File.Delete(fullpath);
                        var ImgMessage = $"the image:{fullpath} was also removed";
                    }
                }
            }
            if (worker != null)
            {

                _uow.Workers.Remove(worker);
                _uow.Commit();
                TempData["message"] = $"{worker.WorkerName} was successfully deleted.{Environment.NewLine}";
            }
            return RedirectToAction("WorkerList");
        }

        public ActionResult DeleteSermon(int Id)
        {
            var _sermon = _uow.Sermons.Find(s => s.Id == Id).FirstOrDefault();
            if (_sermon.ImageUrl != null)
            {
                var filepath = Server.MapPath(@"~/Content/Images");
                List<string> files = Directory.GetFiles(filepath).ToList();
                var fullpath = string.Empty;
                string filename = _sermon.ImageUrl;
                string realfilename = files.Where(i => i.Contains(filename)).FirstOrDefault();
                if (realfilename != null)
                {
                    fullpath = Path.Combine(Server.MapPath("~/Content/Images/"), realfilename);
                    if (System.IO.File.Exists(fullpath))
                    {
                        System.IO.File.Delete(fullpath);
                        var ImgMessage = $"the image:{fullpath} was also removed";
                    }
                }
            }
            if (_sermon != null)
            {

                _uow.Sermons.Remove(_sermon);
                _uow.Commit();
                TempData["message"] = $"{_sermon.Title} was successfully deleted.{Environment.NewLine}";
            }
            return RedirectToAction("SermonList");
        }

        public ActionResult SermonList(int? page)
        {
            var pageSize = 10;
            var sermons = _uow.Sermons.GetAll().ToList().ToPagedList(page ?? 1, pageSize);
            var slvm = new SermonListViewModel
            {
                Sermons = sermons
            };
            ViewBag.page = page;
            ViewBag.PageSize = pageSize;
            return View(slvm);
        }


        public ActionResult WorkerList(int? page)
        {
            var pageSize = 10;
            var workers = _uow.Workers.GetAll().ToList().ToPagedList(page ?? 1, pageSize);
            //var workersbydept = workers.Where(w => w.Department.Name == name).ToList().ToPagedList(page ?? 1, pageSize);
            var wlvm = new WorkerListViewModel
            {
                Workers = workers
            };

            ViewBag.page = page;
            ViewBag.PageSize = pageSize;
            return View(wlvm);
        }

        [HttpGet]
        public ActionResult EventList(int? page)
        {
            var pageSize = 10;
            var events = _uow.Events.GetAll().ToList().ToPagedList(page ?? 1, pageSize);

            var elvm = new EventListViewModel
            {
                Events = events,

            };
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            return View(elvm);
        }

        [HttpGet]
        public ActionResult EditEvent(int id)
        {
            var _event = _uow.Events.Get(id);
            var eventype = _uow.Eventtype.GetAll();
            var _eventtype = _event.Eventtype;
            ViewBag.EventType = new SelectList(eventype, "Name", "Name", _eventtype.Name);
            var evm = new EventViewModel
            {
                EventType = _event.Eventtype.Name,
                EventDate = _event.EventDate,
                EventDescription = _event.EventDescription,
                EventLocation = _event.EventLocation,
                EventName = _event.EventName,
                EventTheme = _event.EventTheme,
                EventImageUrl = _event.EventImageUrl
            };
            return View(evm);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditEvent(EventViewModel evm)
        {
            if (ModelState.IsValid)
            {
                var events = _uow.Events.Get(evm.Id);
                var eventype = _uow.Eventtype.Find(s => s.Name == evm.EventType).FirstOrDefault();


                if (events != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(evm.EventImageFile.FileName);
                    string extension = Path.GetExtension(evm.EventImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    evm.EventImageUrl = fileName;
                    fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);

                    events.EventName = evm.EventName;
                    events.EventTheme = evm.EventTheme;
                    events.EventLocation = evm.EventLocation;
                    events.EventDescription = evm.EventDescription;
                    events.EventImageUrl = evm.EventImageUrl;
                    events.EventImageThumbnailUrl = evm.EventImageUrl;
                    events.EventDate = evm.EventDate;
                    if (evm.EventImageFile != null && evm.EventImageFile.ContentLength > 0)
                    {
                        evm.EventImageFile.SaveAs(fileName);
                    }
                    events.Eventtype = eventype;
                    _uow.Commit();
                    TempData["message"] = $"{events.EventName} was successfully edited.";
                }
                return RedirectToAction("EventList");
            }
            else
            {
                return View(evm);
            }
        }

        public ActionResult DeleteEvent(int Id)
        {

            var _event = _uow.Events.Find(e => e.Id == Id).FirstOrDefault();

            if (_event.EventImageUrl != null)
            {
                var path = Server.MapPath(@"~/Content/images");
                List<string> files = Directory.GetFiles(path).ToList();
                var fullPath = string.Empty;
                var fileName = _event.EventImageUrl;
                var realFileName = files.Where(f => f.Contains(fileName)).FirstOrDefault();

                if (realFileName != null)
                {
                    fullPath = Path.Combine(Server.MapPath("~/Content/Images/"), realFileName);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                        var ImgMessage = $"the image: {fullPath} was also removed.";

                    }

                }
            }

            if (_event != null)
            {
                _uow.Events.Remove(_event);
                _uow.Commit();
                TempData["message"] = $"{_event.EventName} was successfully deleted.{Environment.NewLine}";
            }
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult SermonCategoryList()
        {
            var sermonCategories = _uow.SermonCategories.GetAll();
            var sclvm = new SermonCategoryListViewModel
            {
                SermonCategories = sermonCategories
            };
            return View(sclvm);
        }

        [HttpGet]
        public ActionResult EventTypeList()
        {
            var eventtypes = _uow.Eventtype.GetAll();
            var sclvm = new EventTypeListViewModel
            {
                EventTypes = eventtypes
            };
            return View(sclvm);
        }
        public ActionResult DeleteSermonCategory(int Id)
        {
            var _sermoncategory = _uow.SermonCategories.Find(sc => sc.Id == Id).FirstOrDefault();
            if (_sermoncategory != null)
            {
                _uow.SermonCategories.Remove(_sermoncategory);
                _uow.Commit();
                TempData["message"] = $"{_sermoncategory.SermonName} was successfully deleted.";

            }
            return RedirectToAction("SermonCategoryList");
        }

        [HttpGet]
        public ActionResult AddSermonCategory()
        {
            return View(new SermonCategoryViewModel());
        }


        [HttpGet]
        public ActionResult AddEventType()
        {
            return View(new EventTypeViewModel());
        }
        [HttpPost]
        public ActionResult AddSermonCategory(SermonCategoryViewModel scvm)
        {
            if (ModelState.IsValid)
            {
                var existingcat = _uow.SermonCategories.Find(sc => sc.SermonName == scvm.SermonType.Trim()).FirstOrDefault();
                if (existingcat != null)
                {
                    ModelState.AddModelError("", "This Category name exist before");
                    return View(scvm);
                }
                var cat = new SermonCategory
                {
                    SermonName = scvm.SermonType,
                    Sermons = new List<Sermon>(),
                    SermonDescription = scvm.SermonDescription
                };
                _uow.SermonCategories.Add(cat);
                _uow.Commit();

                TempData["message"] = string.Format("{0} has been saved.", scvm.SermonType);

                return RedirectToAction("SermonCategoryList");
            }
            else
            {

                return View(scvm);
            }
        }

        [HttpPost]
        public ActionResult AddEventType(EventTypeViewModel scvm)
        {
            if (ModelState.IsValid)
            {
                var existingcat = _uow.Eventtype.Find(sc => sc.Name == scvm.Type.Trim()).FirstOrDefault();
                if (existingcat != null)
                {
                    ModelState.AddModelError("", "This Category name exist before");
                    return View(scvm);
                }
                var cat = new EventType
                {
                    Name = scvm.Type,
                    Events = new List<Event>(),
                    Description = scvm.Description
                };
                _uow.Eventtype.Add(cat);
                _uow.Commit();

                TempData["message"] = string.Format("{0} has been saved.", scvm.Type);

                return RedirectToAction("EventTypeList");
            }
            else
            {

                return View(scvm);
            }
        }


        [HttpGet]
        public ActionResult EditSermonCategory(int id)
        {
            var sermoncategory = _uow.SermonCategories.Get(id);
            var scvm = new SermonCategoryViewModel
            {
                Id = sermoncategory.Id,
                SermonType = sermoncategory.SermonName,
                SermonDescription = sermoncategory.SermonDescription
            };
            return View(scvm);
        }
        [HttpGet]
        public ActionResult EditEventType(int id)
        {
            var eventtype = _uow.Eventtype.Get(id);
            var scvm = new EventTypeViewModel
            {
                Id = eventtype.Id,
                Type = eventtype.Name,
                Description = eventtype.Description
            };
            return View(scvm);
        }
        [HttpPost]
        public ActionResult EditSermonCategory(SermonCategoryViewModel scvm)
        {
            if (ModelState.IsValid)
            {
                var sermoncategory = _uow.SermonCategories.Find(sc => scvm.Id == scvm.Id).FirstOrDefault();
                if (sermoncategory != null)
                {
                    sermoncategory.SermonName = scvm.SermonType;
                    sermoncategory.SermonDescription = scvm.SermonDescription;
                    _uow.Commit();
                    TempData["message"] = $"{sermoncategory.SermonName} was successfully edited.";
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(scvm);
            }

        }
        [HttpPost]
        public ActionResult EditEventType(EventTypeViewModel scvm)
        {
            if (ModelState.IsValid)
            {
                var eventtype = _uow.Eventtype.Find(sc => scvm.Id == scvm.Id).FirstOrDefault();
                if (eventtype != null)
                {
                    eventtype.Name = scvm.Type;
                    eventtype.Description = scvm.Description;
                    _uow.Commit();
                    TempData["message"] = $"{eventtype.Name} was successfully edited.";
                }
                return RedirectToAction("EventTypeList");
            }
            else
            {
                return View(scvm);
            }

        }


        public ActionResult DepartmentList(int? page)
        {
            var pageSize = 10;
            var depts = _uow.Departments.GetAll().ToList().ToPagedList(page ?? 1, pageSize);
            var dcvm = new DeptListViewModel { Departments = depts };
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            return View(dcvm);
        }


        [HttpGet]
        public ActionResult AddDept()
        {
            return View(new DeptViewModel());
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddDept(DeptViewModel dcvm)
        {
            if (ModelState.IsValid)
            {
                var existingdept = _uow.Departments.Find(t => t.Name == dcvm.DeptName.Trim()).FirstOrDefault();


                if (existingdept != null)
                {
                    ModelState.AddModelError("", $"A department with the name {dcvm.DeptName} already exists");
                    return View(dcvm);
                }
                string fileName = Path.GetFileNameWithoutExtension(dcvm.ImageFile.FileName);
                string extension = Path.GetExtension(dcvm.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                dcvm.ImageUrl = fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                dcvm.ImageFile.SaveAs(fileName);


                var dept = new Department
                {
                    Name = dcvm.DeptName,
                    Description = dcvm.Description,
                    Location = dcvm.DeptLocation,
                    ImageUrl = dcvm.ImageUrl,
                    ImageThumbnailUrl = dcvm.ImageUrl,
                    DepartmentLeaderName = dcvm.DeptLeaderName,

                };
                _uow.Departments.Add(dept);
                _uow.Commit();

                TempData["message"] = string.Format("{0} has been saved.", dcvm.DeptName);



                return RedirectToAction("DepartmentList");
            }
            else
            {

                return View(dcvm);
            }
        }

        [HttpGet]
        public ActionResult EditDept(int id)
        {
            var _dept = _uow.Departments.Get(id);
            var dvm = new DeptViewModel
            {
                DeptLeaderName = _dept.DepartmentLeaderName,
                // DeptLeaderIamgeUrl=_dept.LeaderImageUrl,
                // DeptMeeting=_dept.MeetingDay,
                DeptLocation = _dept.Location,
                DeptName = _dept.Name,
                Description = _dept.Description,
                ImageUrl = _dept.ImageUrl


            };
            return View(dvm);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult EditDept(DeptViewModel dvm)
        {
            if (ModelState.IsValid)
            {
                var _depts = _uow.Departments.Get(dvm.Id);
                if (_depts != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(dvm.ImageFile.FileName);
                    string extension = Path.GetExtension(dvm.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    dvm.ImageUrl = fileName;
                    fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);

                    _depts.Name = dvm.DeptName;
                    _depts.Description = dvm.Description;
                    _depts.Location = dvm.DeptLocation;
                    //_depts.MeetingDay = dvm.DeptMeeting;
                    _depts.ImageUrl = dvm.ImageUrl;
                    _depts.ImageThumbnailUrl = dvm.ImageUrl;
                    _depts.DepartmentLeaderName = dvm.DeptLeaderName;


                    if (dvm.ImageFile != null && dvm.ImageFile.ContentLength > 0)
                    {
                        dvm.ImageFile.SaveAs(fileName);
                    }
                    _uow.Commit();
                    TempData["message"] = $"{_depts.Name} was successfully edited.";
                }



                // _mailService.Send("A new department added", $"Department {dvm.DeptName}, and the Department Leader{dvm.DeptLeaderName} ");
                return RedirectToAction("DepartmentList");
            }
            else
            {
                return View(dvm);
            }
        }

        [HttpGet]
        public ActionResult UserList()
        {
            List<IUser> users = _uow.Users.UserList;
            List<User> userlist = users.Select(c => (User)c).ToList();
            var ulvm = new UserListViewModel
            {
                Users = userlist
            };
            return View(ulvm);
        }



    }
}