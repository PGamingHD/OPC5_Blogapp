using OPC5_Blogapp.Data;
using OPC5_Blogapp.Data.Models;

namespace Services.Tags
{
    public class TagService(ApplicationDbContext _context) : ITagService
    {
        private readonly ApplicationDbContext context = _context;

        public List<Tag> GetTags()
        {
            List<Tag> allTags = context.Tag.ToList();

            return allTags;
        }

        public void AddTag(Tag tag)
        {
            context.Tag.Add(tag);
            context.SaveChanges();
        }
    }
}
