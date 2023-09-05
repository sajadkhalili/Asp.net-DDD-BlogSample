using BlogApp.Contracts.Posts.Repositories;
using BlogApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDbContext _context;

        public PostRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Post post, CancellationToken cancellationToken = default)
        {
            await _context.Posts.AddAsync(post, cancellationToken);
        }

        public async Task RemoveAsync(Post post, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => _context.Posts.Remove(post), cancellationToken);
        }

        public async Task<List<Post>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Posts.ToListAsync(cancellationToken);
        }

        public async Task<Post> GetByIdAsync(string postId, CancellationToken cancellationToken = default)
        {
            return await _context.Posts.SingleOrDefaultAsync(p => p.Id == postId, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Post post, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => _context.Entry(post).State = EntityState.Modified);
        }
    }
}
