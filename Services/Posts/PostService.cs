using Microsoft.EntityFrameworkCore;
using OPC5_Blogapp.Data;
using OPC5_Blogapp.Data.Models;

namespace Services.Posts
{
    public class PostService(ApplicationDbContext _context) : IPostService
    {
        private readonly ApplicationDbContext context = _context;

        public int? AddPost(Post post)
        {
            context.Posts.Add(post);
            context.SaveChanges();

            return post.PostId;
        }

        public Post? AddPostUpvote(int postId)
        {
            Post? foundPost = context.Posts.FirstOrDefault(p => p.PostId == postId);

            if (foundPost != null)
            {
                foundPost.PostUpvotes += 1;

                context.SaveChanges();

                return foundPost;
            }

            return foundPost;
        }

        public Post? AddPostDownvote(int postId)
        {
            Post? foundPost = context.Posts.FirstOrDefault(p => p.PostId == postId);

            if (foundPost != null)
            {
                foundPost.PostDownvotes += 1;

                context.SaveChanges();

                return foundPost;
            }

            return foundPost;
        }

        public async Task<List<Post>> GetPosts(int count)
        {
            return await context.Posts.Include(p => p.User)
                .Include(p => p.PostTags)
                .Include(p => p.PostComments)
                .OrderByDescending(p => p.PostId)
                .Take(count)
                .ToListAsync();
        }

        public async Task<int> GetTotalPostCount()
        {
            return await context.Posts.CountAsync();
        }

        public List<Comment> GetPostComments(int postId)
        {
            Post? post = context.Posts.FirstOrDefault(p => p.PostId == postId);

            if (post == null) return new List<Comment>();

            List<Comment> postComments = post.PostComments.ToList();

            return postComments;
        }

        public Post? RemovePostUpvote(int postId)
        {
            Post? foundPost = context.Posts.FirstOrDefault(p => p.PostId == postId);

            if (foundPost != null)
            {
                foundPost.PostUpvotes -= 1;

                context.SaveChanges();

                return foundPost;
            }

            return foundPost;
        }

        public Post? RemovePostDownvote(int postId)
        {
            Post? foundPost = context.Posts.FirstOrDefault(p => p.PostId == postId);

            if (foundPost != null)
            {
                foundPost.PostDownvotes -= 1;

                context.SaveChanges();

                return foundPost;
            }

            return foundPost;
        }
    }
}
