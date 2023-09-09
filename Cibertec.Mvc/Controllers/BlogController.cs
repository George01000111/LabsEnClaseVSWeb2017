using Cibertec.Mvc.Models;
using Cibertec.UnitOfWork;
using log4net;
using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.Mvc.Controllers
{
    public class BlogController : BaseController
    {
        public BlogController(ILog log, IUnitOfWork unit) : base(log, unit)
        {
        }

        // GET: Blog
        public ActionResult Index()
        {
            
            return View(new List<Post>());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            var description = Sanitizer.GetSafeHtmlFragment(post.Description);
            var p = post;
            return View();
        }
    }
}