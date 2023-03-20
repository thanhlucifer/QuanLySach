using Sang4_Tuan4_2011064477_PhamVanThanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sang4_Tuan4_2011064477_PhamVanThanh.Controllers
{
    public class TheLoaiController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: TheLoai

        public ActionResult ListTheLoai()
        {
            //Thuc hien truy van de lay sach
            var all_theloai = from ss in data.TheLoais select ss;
            //Do du lieu vao giao dien
            return View(all_theloai);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, TheLoai s)
        {
            var E_tenloai = collection["tenloai"];

            if (string.IsNullOrEmpty(E_tenloai))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.tenloai = E_tenloai.ToString();
                
                data.TheLoais.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("ListTheLoai");
            }
            return this.Create();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}