using PopEyeTrip.Entities;
using System.Collections.Generic;

namespace PopEyeTrip.Abstract
{
    public interface IBannerRepository
    {
        IEnumerable<Banner> Banners { get; }
        void SaveBanner(Banner banner);
        Banner DeleteBanner(int bannerID);
    }
}
