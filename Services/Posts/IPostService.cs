using OPC5_Blogapp.Data.Models;

namespace Services.Posts
{
    public interface IPostService
    {
        int? AddPost(Post post);
        Post? AddPostUpvote(int postId);
        Post? AddPostDownvote(int postId);
        Task<List<Post>> GetPosts(int count);
        Task<int> GetTotalPostCount();
        List<Comment> GetPostComments(int postId);
        Post? RemovePostUpvote(int postId);
        Post? RemovePostDownvote(int postId);
    }
}
