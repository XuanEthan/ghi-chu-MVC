using BaoCao1.Models;
using BaoCao1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult> List()
        {
            var list = await _ghichuService.GetAllitems();

            return PartialView("List" , list);
        }
        // GET: GhichusController/Details/5
        public ActionResult Details(int id)
        {
            return PartialView();
        }

        // GET: GhichusController/Create
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
        public async Task<IActionResult> Create([FromBody] Ghichu formData)
        {
           //return Json{
           //     await _ghichuService.Insert(formData)
           // }
        }

        // GET: GhichusController/Edit/5
        [HttpGet]
        [Route("/Ghichus/Edit/{id}")]
        public async Task<ActionResult> Edit(long id)
        {
            var res = await _ghichuService.GetById(id);
            ViewBag.Action = "2";
            return PartialView("Edit", res);
        }

        // POST: GhichusController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(IFormCollection collection)
        {
            //try
            //{
            //    var res = await _ghichuService.Update(new Ghichu { Id = long.Parse(collection["Id"]) , Tieude = collection["Tieude"] , Noidung = collection["Noidung"] });
            //    if (res != null)
            //    {
            //        return RedirectToAction("Index");
            //    }
            //    else
            //    {
            //        return View("Error", new ErrorViewModel { Message = "Sửa không thành công . Hãy thử lại lần sau!" });
            //    }
            //}
            //catch(Exception ex)
            //{
            //    return View("Error", new ErrorViewModel { Message = "Sửa không thành công . Hãy thử lại lần sau!" });
            //}
        }

        [HttpGet]
        [Route("/Ghichus/Delete/{id}")]
        public async Task<IActionResult> ConfirmDelete(long id)
        {
            var ghichu = await _ghichuService.GetById(id);
            return PartialView("Delete" , ghichu);
        }
        
        // POST: GhichusController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(IFormCollection collection)
        {
            //try
            //{
            //    var res = await _ghichuService.Delete(long.Parse(collection["Id"]));
            //    if (res > 0)
            //    {
            //        return RedirectToAction("Index");
            //    }
            //    else
            //    {
            //        return View("Error", new ErrorViewModel { Message = "Xóa không thành công . Hãy thử lại lần sau !" });
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return View("Error", new ErrorViewModel { Message = ex.Message });
            //}
        }
    }
}
