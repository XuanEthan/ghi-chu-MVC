using BaoCao1.Models;
using BaoCao1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace BaoCao1.Controllers
{
    public class GhichusController : Controller
    {
        private IGhichuService _ghichuService;
        public GhichusController(IGhichuService ghichuService)
        {
            _ghichuService = ghichuService;
        }

        // GET: GhichusController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/Ghichus/List")]
        public async Task<ActionResult> List(string? search)
        {
            var filter = new Ghichu_TimkiemModel {search = search};
            var list = await _ghichuService.GetAllitems(filter);

            return PartialView("List" , list);
        }
        // GET: GhichusController/Details/5
        public ActionResult Details(int id)
        {
            return PartialView();
        }

        //[Route("/Ghichus/Create")]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Action = "1";
            var ghichu = GhichuService.initEmpty();
            return PartialView("Edit" , ghichu);
        }

        // POST: GhichusController/Create
        [HttpPost]
        [Route("/Ghichus/Create")]
        public async Task<IActionResult> Create(Ghichu ghichu)
        {
            return Json(await _ghichuService.Insert(ghichu));
        }

        // GET: GhichusController/Edit/5
        [HttpGet]
        [Route("/Ghichus/Edit/{id}")]
        public async Task<ActionResult> Edit(long id)
        {
            var res = await _ghichuService.GetById(id);
            ViewBag.Action = "2";
            return PartialView("Edit", res.Object);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Ghichu formData)
        {
          return Json(await _ghichuService.Update(formData));
        }

        [HttpPost]
        [Route("/Ghichus/Delete/{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id)
        {
            return Json(await _ghichuService.Delete(id));
        }
    }
}
