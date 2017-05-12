using KisiselBlog.Services.EtiketService;
using KisiselBlog.Services.MakaleServices;
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
        private readonly IMakaleServices _makaleService;


        public EtiketController(IEtiketService etiketService, IMakaleServices makaleService)
        {
            _etiketSerivce = etiketService;
            _makaleService = makaleService;
        }

        public ActionResult Index(int id)
        {
            return View(id);
        }

        public PartialViewResult  EtiketlerWidget()
        {
            return PartialView(_etiketSerivce.GetAll());
        }

        public ActionResult MakaleListele(int id)
        {
            var data = _makaleService.GetAll(m => m.Etiket.Any(y => y.EtiketId == id));

                return View("MakaleListeleWidget",data);
        }
    }
}