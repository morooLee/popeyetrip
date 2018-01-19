using PopEyeTrip.Abstract;
using PopEyeTrip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopEyeTrip.Concrete
{
    public class EFHashTagRepository : IHashTagRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<HashTag> HashTags
        {
            get { return context.HashTags; }
        }

        public IEnumerable<HashTag_MainDetail> HashTag_MainDetails
        {
            get { return context.HashTag_MainDetails; }
        }
        // 메인보드 해시태그 수정
        public void ChangeHashTags(List<HashTag_MainDetail> HashTag_MainDetails, int MainBoard_DetailID)
        {
            List<HashTag_MainDetail> dbEntries = context.HashTag_MainDetails.Where(p => p.MainBoard_DetailID == MainBoard_DetailID).ToList();
            for (int i = 0; i < dbEntries.Count; i++)
            {
                if (!HashTag_MainDetails.Contains(dbEntries[i]))
                {
                    context.HashTag_MainDetails.Remove(dbEntries[i]);
                }
            }
            for (int i = 0; i < HashTag_MainDetails.Count; i++)
            {
                if (!dbEntries.Contains(HashTag_MainDetails[i]))
                {
                    context.HashTag_MainDetails.Add(HashTag_MainDetails[i]);
                }
            }

            context.SaveChanges();
        }
        // 메인보드 해시태그 삭제
        public void DeleteHashTags(int MainBoard_DetailID)
        {
            IEnumerable<HashTag_MainDetail> dbEntries = context.HashTag_MainDetails.Where(p => p.MainBoard_DetailID == MainBoard_DetailID);
            foreach (HashTag_MainDetail dbEntry in dbEntries)
            {
                if (dbEntry != null)
                {
                    context.HashTag_MainDetails.Remove(dbEntry);
                }
            }
            context.SaveChanges();
        }
    }
}
