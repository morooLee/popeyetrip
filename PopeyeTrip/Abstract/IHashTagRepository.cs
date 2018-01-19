using PopEyeTrip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopEyeTrip.Abstract
{
    public interface IHashTagRepository
    {
        IEnumerable<HashTag> HashTags { get; }
        IEnumerable<HashTag_MainDetail> HashTag_MainDetails { get; }
        void ChangeHashTags(List<HashTag_MainDetail> HashTag_MainDetails, int MainBoard_DetailID);
        void DeleteHashTags(int MainBoard_DetailID);
    }
}
