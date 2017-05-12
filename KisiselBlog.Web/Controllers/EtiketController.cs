using KisiselBlog.Services.EtiketService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KisiselBlog.Web.Controllers
{
    public class EtiketController : Controller
    {

        private readonly IEtiketService _etiketSerivce;

        public EtiketController(IEtiketService etiketService)
        {
            _etiketSerivce = etiketService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult  EtiketlerWidget()
        {
            return PartialView(_etiketSerivce.GetAll());
        }
    }
}