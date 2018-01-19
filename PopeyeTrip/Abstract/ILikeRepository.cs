using PopEyeTrip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopEyeTrip.Abstract
{
    public interface ILikeRepository
    {
        IEnumerable<PopEyeLike> Likes { get; }
        void SaveLike(PopEyeLike like);
    }
}
