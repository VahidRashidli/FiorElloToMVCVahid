using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TemplatePractice.Models;

namespace TemplatePractice.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        public DbSet<AboutSection> AboutSections { get; set; }
        public DbSet<InfoList> InfoLists { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<ExpertSection> ExpertSections { get; set; }
        public DbSet<ExpertImage> ExpertImages { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<FooterCategory> FooterCategories { get; set; }
        public DbSet<FooterCategorySection> FooterCategorySections { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogPicture> BlogPictures { get; set; }
        public DbSet<SaySection> SaySections { get; set; }
        public DbSet<InstagramSection> InstagramSections { get; set; }
        public DbSet<InstagramSectionPicture> InstagramSectionPictures { get; set; }
    }
}
