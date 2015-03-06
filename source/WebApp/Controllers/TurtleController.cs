using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class TurtleController : Controller
    {
        //
        // GET: /Turtle/

        public ActionResult Index()
        {
            return View();
        }


        // POST: /Turtle/Draw
        [HttpPost]
        public ActionResult Draw(DrawModel model)
        {
            string userScript = model.UserScript;
            return Json(new { success = true });
        }

    }
}
