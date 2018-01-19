using PopEyeTrip.Abstract;
using PopEyeTrip.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PopEyeTrip.Controllers
{
    [AllowAnonymous]
    public class SliderController : BaseController
    {
        private IBannerRepository repository;

        public SliderController(IBannerRepository bannerRepository)
        {
            this.repository = bannerRepository;
        }

        // GET: Slider
        public PartialViewResult BannerShow()
        {
            return PartialView(repository.Banners);
        }

        public PartialViewResult Index()
        {
            return PartialView(repository.Banners);
        }

        //public
        //[HttpPost]
        //public ActionResult AddBanner(HttpPostedFileBase ImagePath)
        //{
        //    if (ImagePath != null)
        //    {
        //        Image img = Image.FromStream(ImagePath.InputStream);
        //        if (img.Width != 1920 || img.Height != 1080)
        //        {
        //            ModelState.AddModelError("", "Image resolution must be 1920 x 1080 pixels");
        //            return View();
        //        }

        //        string pic = Path.GetFileName(ImagePath.FileName);
        //        string path = Path.Combine(Server.MapPath("~/Resources/"), pic);
        //        ImagePath.SaveAs(path);

        //        using (EFDbContext db = new EFDbContext())
        //        {
        //            Banner banner = new Banner { ImagePath = "~/Resources/" + pic, LinkUrl = null, RegisterTime = DateTime.Now, FinishTime = DateTime.Now, Writer = null };
        //            repository.Banners.Add(banner);
        //            db.SaveChanges();
        //        }
        //    }
        //    return RedirectToAction("Slider");
        //}

        //public ActionResult DeleteBanners()
        //{
        //    using (EFDbContext db = new EFDbContext())
        //    {
        //        return View(db.Banners.ToList());
        //    }
        //}

        //[HttpPost]
        //public ActionResult DeleteBanners(IEnumerable<int> ImagesIDs)
        //{
        //    using (EFDbContext db = new EFDbContext())
        //    {
        //        foreach (var id in ImagesIDs)
        //        {
        //            var image = db.Banners.Single(s => s.ID == id);
        //            string imgPath = Server.MapPath(image.ImagePath);
        //            db.Banners.Remove(image);
        //            if (System.IO.File.Exists(imgPath))
        //            {
        //                System.IO.File.Delete(imgPath);
        //            }
        //        }
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("DeleteBanners");
        //}
    }
}