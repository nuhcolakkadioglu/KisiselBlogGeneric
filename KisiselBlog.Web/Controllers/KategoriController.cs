using KisiselBlog.Services.KategoriService;
using KisiselBlog.Services.MakaleServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KisiselBlog.Web.Controllers
{
    public class KategoriController : Controller
    {

        private readonly IKategoriService _kategoriService;
        private readonly IMakaleServices _makaleService;

        public KategoriController(IKategoriService kategoriService, IMakaleServices makaleService)
        {
            _kategoriService = kategoriService;
            _makaleService = makaleService;
        }

        public ActionResult Index(int id)
        {
            return View(id);
        }

        public PartialViewResult KategoriWidget()
        {
            return PartialView(_kategoriService.GetAll().OrderBy(m=>m.Adi));
        }

        public ActionResult MakaleListele(int id)
        {
            var data = _makaleService.GetAll(m=>m.KategoriID==id);
            return View("MakaleListeleWidget", data);
        }
    }
}