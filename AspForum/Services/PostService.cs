using AspForum.Data;
using AspForum.Interfaces;
using AspForum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspForum.Services
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;
        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync(); 
        }

        public async Task Delete(int postId)
        {
            Post post = new Post { Id = postId };
            _context.Posts.Attach(post);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts;               
        }

        public Post GetById(int id)
        {
            return _context.Posts
                .Where(p => p.Id == id)
                .Include(p => p.topic)
                .Include(t => t.User)
                .FirstOrDefault();

            
        }

        public IEnumerable<Post> GetPostsForTopic(int topicId)
        {
            return _context.Topics
                .Where(t => t.Id == topicId)
                .First()
                .Posts;
           
        }

        public async Task UpdatePostContent(int postId, string newContent)
        {
            var editedPost = _context.Posts
                .Where(p => p.Id == postId)
                .FirstOrDefault();
            editedPost.Content = newContent;
            await _context.SaveChangesAsync();
        }

        public Task UpdatePostTitle(int postId, string newTitle)
        {
            throw new NotImplementedException();
        }
    }
}
