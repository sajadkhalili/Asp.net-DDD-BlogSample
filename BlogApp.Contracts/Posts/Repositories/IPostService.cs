using BlogApp.Contracts.Posts.Commands.CreatePost;
using BlogApp.Contracts.Posts.Commands.GetPost;

namespace BlogApp.Contracts.Posts.Repositories
{
    public interface IPostService
    {
        Task<GetPostResult> GetPostAsync(GetPostRequest request, CancellationToken cancellationToken = default);
        Task<CreatePostResult> CreatePostAsync(CreatePostRequest request, CancellationToken cancellationToken = default);
    }
}
