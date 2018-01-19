using PopEyeTrip.Entities;
using System.Data.Entity;

namespace PopEyeTrip.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Banner> Banners { get; set; }
        public DbSet<MainBoard_List> MainBoardLists { get; set; }
        public DbSet<MainBoard_Detail> MainBoardDetails { get; set; }
        public DbSet<MainBoard_Point> MainBoardPoints { get; set; }
        public DbSet<MainBoard_KoreanStudy> MainBoardStudies { get; set; }
        public DbSet<MainBoard_StillCut> MainBoardStillCuts { get; set; }
        public DbSet<HashTag> HashTags { get; set; }
        public DbSet<HashTag_MainDetail> HashTag_MainDetails { get; set; }
        public DbSet<PopEyeLike> Likes { get; set; }

        public EFDbContext() : base("EFConnection")
        {
        }

        public static EFDbContext Create()
        {
            return new EFDbContext();
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasDefaultSchema("DefaultConnection");

        //    유창함 API 구성
        //}
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    // Configure StudentId as PK for StudentAddress
        //    modelBuilder.Entity<MainBoard_List>()
        //        .HasKey(e => e.MainBoard_DetailID);

        //    // Configure StudentId as FK for StudentAddress
        //    modelBuilder.Entity<MainBoard_List>()
        //                .HasRequired(ad => ad.MainBoard_Details)
        //                .WithOptional(s => s.MainBoard_Lists);

        //}
    }
}
