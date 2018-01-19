using PopEyeTrip.Abstract;
using PopEyeTrip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopEyeTrip.Concrete
{
    public class EFLikeRepository : ILikeRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<PopEyeLike> Likes
        {
            get { return context.Likes; }
        }

        public void SaveLike(PopEyeLike like)
        {
            if (like.ID == 0)
            {
                context.Likes.Add(like);
            }
            else
            {
                PopEyeLike dbEntry = context.Likes.Where(m => m.MainBoard_DetailID == like.MainBoard_DetailID).FirstOrDefault(m => m.UserID == like.UserID);
                if (dbEntry == null)
                {
                    context.Likes.Add(like);
                }
            }
            context.SaveChanges();
        }
    }
}
