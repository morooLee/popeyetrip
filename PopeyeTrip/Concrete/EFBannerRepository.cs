using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PopEyeTrip.Entities;
using PopEyeTrip.Abstract;

namespace PopEyeTrip.Concrete
{
    public class EFBannerRepository : IBannerRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Banner> Banners
        {
            get { return context.Banners; }
        }

        public void SaveBanner(Banner banner)
        {
            if (banner.ID == 0)
            {
                context.Banners.Add(banner);
            }
            else
            {
                Banner dbEntry = context.Banners.Find(banner.ID);
                if (dbEntry != null)
                {
                    dbEntry.ID = banner.ID;
                    dbEntry.ImagePath = banner.ImagePath;
                    dbEntry.LinkUrl = banner.LinkUrl;
                    dbEntry.RegisterDate = banner.RegisterDate;
                    dbEntry.StartDate = banner.StartDate;
                    dbEntry.EndDate = banner.EndDate;
                    dbEntry.Writer = banner.Writer;
                }
            }
            context.SaveChanges();
        }

        public Banner DeleteBanner(int bannerID)
        {
            Banner dbEntry = context.Banners.Find(bannerID);
            if (dbEntry != null)
            {
                context.Banners.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
