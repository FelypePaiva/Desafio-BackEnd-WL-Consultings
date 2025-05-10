using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_BackEnd_WL_Consultings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        // GET: UsuarioController
        //[HttpGet(Name = "Usuario")]
        [HttpGet]
        public ActionResult Index()
        {
            return Ok();
        }

        //// GET: UsuarioController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return Ok();
        //}

        //// GET: UsuarioController/Create
        //public ActionResult Create()
        //{
        //    return Ok();
        //}

        //// POST: UsuarioController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return Ok();
        //    }
        //}

        //// GET: UsuarioController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return Ok();
        //}

        //// POST: UsuarioController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return Ok();
        //    }
        //}

        //// GET: UsuarioController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return Ok();
        //}

        //// POST: UsuarioController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return Ok();
        //    }
        //}
    }
}
