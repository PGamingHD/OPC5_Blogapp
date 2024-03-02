using OPC5_Blogapp.Data;
using OPC5_Blogapp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.Posts
{
    public class CommentService(ApplicationDbContext _context) : ICommentService
    {
        private readonly ApplicationDbContext context = _context;

        public async Task AddComment(Comment comment)
        {
            context.Comment.Add(comment);
            context.SaveChanges();
        }

        public List<Comment> GetComments()
        {
            List<Comment> allComments = context.Comment.ToList();

            return allComments;
        }

        public async Task<int> GetCommentsCount(int postId)
        {
            // Retrieve the count of comments for the specified post
            var commentsCount = await _context.Comment
                .Where(c => c.PostId == postId)
                .CountAsync();

            return commentsCount;
        }
    }
}
