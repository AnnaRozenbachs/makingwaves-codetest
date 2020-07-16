using MakingWavesCodeTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakingWavesCodeTest.Controllers
{
    public class HomeController : Controller
    {
        APIService APIservice = new APIService();
        public ActionResult Index()
        {
            List<Dictionary<string,string>> dataList= APIservice.GetDataList();
            return View();
        }
    }
}