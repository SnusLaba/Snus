using SnusSite.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SnusSite.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/

        public ActionResult LeftMenu()
        {
            return PartialView("_LeftMainMenu", new MenuModel());
        }

    }
}
