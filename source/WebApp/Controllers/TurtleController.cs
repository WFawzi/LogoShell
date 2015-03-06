using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using Engine; //You have to add it through Refrences -> add refernce


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
        [HttpPost]          //We have to add this, so that the client can POST to this server method, if we do not add it, then the default behavior is GET
        public ActionResult Draw(DrawModel model)
        {
            string userScript = model.UserScript;

            //
            // Passs the direction, X, Y and user script to the Engine
            // Gets a turtle from the engine

            Turtle turtle = PowerShellEnvironment.ExecuteTurtleScript(model.X, model.Y, model.Direction, model.UserScript);
            //


            //return Json(new { success = true });
            return Json(new
            {
                direction = turtle.Direction,
                x = turtle.Position.X,
                y = turtle.Position.Y,
                path = turtle.Path.Select(p => new { x = p.X, y = p.Y })
            });
        }

    }
}
