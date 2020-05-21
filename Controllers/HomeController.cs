using Rating_Comment.Models;
using Rating_Comment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rating_Comment.Controllers
{
    public class HomeController : Controller
    {
        private SampleEntities db;

        public HomeController()
        {
            db = new SampleEntities();
        }
      
        public ActionResult Index()
        {
            var item = (from d in db.tbl_platter
                        select d).ToList();

            return View(item);
        }

        [HttpGet]
        public ActionResult Addplatter()
        {
            tbl_platter p = new tbl_platter();
            return View(p);
        }

        [HttpPost]
        public ActionResult Addplatter(tbl_platter model1, HttpPostedFileBase image1)
        {
            if (image1 != null)
            {
                model1.platter_image = new byte[image1.ContentLength];
                image1.InputStream.Read(model1.platter_image, 0, image1.ContentLength);
            }
            db.tbl_platter.Add(model1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Review(int platterId)
        {
            IEnumerable<CommentViewModel> item = (from d in db.Comments
                        where d.platter_id == platterId
                        select new CommentViewModel()
                        {
                            platter_id = d.platter_id,
                            comment_description = d.comment_description,
                            comment_id = d.comment_id,
                            commentedOn = d.commentedOn,
                            rating = d.rating   
                        }).ToList();
            ViewBag.platter_id = platterId;
            return View(item);
        }

        [HttpPost]
        public ActionResult AddComment(int platterId, int rating, string platterComment)
        {
            Comment obj = new Comment();
            obj.platter_id = platterId;
            obj.comment_description = platterComment;
            obj.commentedOn = DateTime.Now;
            obj.rating = rating;
            obj.guest_id = Guid.NewGuid();
            db.Comments.Add(obj);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        //public ActionResult Vote(int platterId)
        //{
          
        //    return View();
        //}


    }
}