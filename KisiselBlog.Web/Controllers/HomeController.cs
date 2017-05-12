using KisiselBlog.Services.KategoriService;
using KisiselBlog.Services.MakaleServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KisiselBlog.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IMakaleServices _makaleServices;
        private readonly IKategoriService _kategoriService;

        public HomeController(IMakaleServices makaleServices,IKategoriService kategoriService)
        {
            _makaleServices = makaleServices;
            _kategoriService = kategoriService;
        }

        public ActionResult Index()
        {
            return View(_kategoriService.GetAll());
        }

        public ActionResult MakaleListele()
        {
            var data = _makaleServices.GetAll().OrderByDescending(m => m.EklenmeTarihi);
            return View("MakaleListeleWidget", data);
        }

        public PartialViewResult PopulerMakalelerWidget()
        {
            return PartialView(_makaleServices.GetAll().OrderByDescending(m=>m.GoruntulenmeSayisi).Take(3));
        }
    }
}