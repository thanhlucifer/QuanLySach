using PagedList;
using Sang4_Tuan4_2011064477_PhamVanThanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sang4_Tuan4_2011064477_PhamVanThanh.Controllers
{
    public class HomeController : Controller
    {
        MyDataDataContext dt = new MyDataDataContext();
        public ActionResult Index(int ? page)
        {
            if (page == null) page = 1;
            var all_sach = (from ss in dt.Saches select ss).OrderBy(m => m.masach);
            int pageSize = 3;
            int pageNum = page ?? 1;

            return View(all_sach.ToPagedList(pageNum, pageSize));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}