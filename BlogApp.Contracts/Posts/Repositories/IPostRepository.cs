using BlogApp.Domain.Entities;

namespace BlogApp.Contracts.Posts.Repositories
{
    public interface IPostRepository
    {
        Task<Post> GetByIdAsync(string postId, CancellationToken cancellationToken = default);
        Task<List<Post>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(Post post, CancellationToken cancellationToken = default);
        Task UpdateAsync(Post post, CancellationToken cancellationToken = default);
        Task RemoveAsync(Post post, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
