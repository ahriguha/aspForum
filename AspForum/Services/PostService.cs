using AspForum.Data;
using AspForum.Interfaces;
using AspForum.Models;
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

        public Task Create(Post post)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int postId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public Post GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostsForTopic(int topicId)
        {
            return _context.Topics
                .Where(t => t.Id == topicId)
                .First()
                .Posts;
           
        }

        public Task UpdatePostContent(int postId, string newContent)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePostTitle(int postId, string newTitle)
        {
            throw new NotImplementedException();
        }
    }
}
