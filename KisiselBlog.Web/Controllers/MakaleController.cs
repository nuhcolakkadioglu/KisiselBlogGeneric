using KisiselBlog.Services.MakaleServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KisiselBlog.Web.Controllers
{
    public class MakaleController : Controller
    {
        private readonly IMakaleServices _makaleServices;
        public MakaleController(IMakaleServices makaleService)
        {
            _makaleServices = makaleService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detay(int id)
        {
            return View(_makaleServices.Find(id));
        }
    }
}