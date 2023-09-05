using BlogApp.Contracts.Posts.Commands.CreatePost;
using BlogApp.Contracts.Posts.Commands.GetPost;
using BlogApp.Contracts.Posts.Repositories;
using BlogApp.Domain.Entities;

namespace BlogApp.Application.Posts
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<CreatePostResult> CreatePostAsync(CreatePostRequest request, CancellationToken cancellationToken = default)
        {
            var post = new Post(request.Title , request.Content);
            await _postRepository.AddAsync(post);
            try
            {
                await _postRepository.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
            return new CreatePostResult(post.Id);
        }

        public async Task<GetPostResult> GetPostAsync(GetPostRequest request, CancellationToken cancellationToken = default)
        {
            var post = await _postRepository.GetByIdAsync(request.Id, cancellationToken);
            return new GetPostResult
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content
            };
        }


    }
}
