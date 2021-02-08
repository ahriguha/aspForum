using AspForum.Data;
using AspForum.Interfaces;
using AspForum.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspForum.Services
{
    public class TopicService : ITopic
    {

        private readonly ApplicationDbContext _context;
        public TopicService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task Create(Topic topic)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int topicId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topic> GetAll()
        {
            return _context.Topics
                .Include(t => t.Posts);
        }

        public IEnumerable<IdentityUser> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        public Topic GetById(int id)
        {
            var topic = _context.Topics.Where(t => t.Id == id)
                .Include(t => t.Posts)
                .ThenInclude(p => p.User)
                .FirstOrDefault();
            return topic;
        }

        public Task UpdateTopicDescription(int topicId, string newDescription)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTopicTitle(int topicId, string newTitle)
        {
            throw new NotImplementedException();
        }
    }
}
