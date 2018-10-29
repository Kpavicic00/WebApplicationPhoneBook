using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationBOOK.Models;

namespace WebApplicationBOOK.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult GetContact()
        {
            using (DatabaseEntities1 db = new DatabaseEntities1())
            {
                var korisnici = db.Korisnikks.OrderBy(a => a.FirstName).ToList();
                return Json(new { data = korisnici }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult Save( int id)
        {

            using (DatabaseEntities1 dq = new DatabaseEntities1())
            {
                var var1 = dq.Korisnikks.Where(a => a.Korisnik_Id == id).FirstOrDefault();
                return View(var1);
            }
        }
        [HttpPost]
        public ActionResult Save(Korisnikk kor)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (DatabaseEntities1 dq = new DatabaseEntities1())
                {
                    if (kor.Korisnik_Id>0)
                    {
                        var varr = dq.Korisnikks.Where(a => a.Korisnik_Id == kor.Korisnik_Id).FirstOrDefault();
                        if (varr != null) 
                        {
                            varr.FirstName = kor.FirstName;
                            varr.LastName = kor.LastName;
                            varr.AdressName = kor.AdressName;
                            varr.E_mail = kor.E_mail;
                            varr.Tel_broj = kor.Tel_broj;
                            varr.Vrsta_tel_broja = kor.Vrsta_tel_broja;
                        }
                    }
                    else
                    {
                        dq.Korisnikks.Add(kor);
                    }
                    dq.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (DatabaseEntities1 db = new DatabaseEntities1())
            {
                var va = db.Korisnikks.Where(a => a.Korisnik_Id == id).FirstOrDefault();
                if (va != null) 
                {
                    return View(va);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteKorisnik(int id)
        {
            bool status = false;
            using (DatabaseEntities1 db = new DatabaseEntities1())
            {
                var v = db.Korisnikks.Where(a => a.Korisnik_Id == id).FirstOrDefault();
                if (v != null) 
                {
                    db.Korisnikks.Remove(v);
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}












