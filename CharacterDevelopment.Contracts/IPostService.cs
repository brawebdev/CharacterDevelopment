using CharacterDevelopment.Models.Post;
using System.Collections.Generic;

namespace CharacterDevelopment.Contracts
{
    public interface IPostService
    {
        bool CreatePost(PostCreate model);
        IEnumerable<PostListItem> GetPosts();
        PostDetail GetPostById(int postId);
        bool UpdatePost(PostEdit model);
        bool DeletePost(int postId);
    }
}
