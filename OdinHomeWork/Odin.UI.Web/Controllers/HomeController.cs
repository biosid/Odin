using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Odin.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult MainPage()
        {
            return View();
        }

        public JsonResult GetConfiguration()
        {
            var config = new ApplicationConfigModel()
            {
                DebugMode = Request.IsLocal,
                //todo: Нужно указать ссылку на ресурс WebApi
                WebApiUrl = WebConfigurationManager.AppSettings["WebApiUrl"]
            };

            return Json(new
            {
                config
            }, JsonRequestBehavior.AllowGet);
        }
    }

    /// <summary>
    /// Класс конфигурации для angular приложения
    /// </summary>
    public class ApplicationConfigModel
    {
        /// <summary>
        /// Режим отладки
        /// </summary>
        public bool DebugMode { get; set; }

        public string WebApiUrl { get; set; }
    }
}
