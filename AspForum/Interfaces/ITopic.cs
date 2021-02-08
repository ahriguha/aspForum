using AspForum.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspForum.Interfaces
{
    public interface ITopic
    {
        Topic GetById(int id);
        IEnumerable<Topic> GetAll();
        IEnumerable<IdentityUser> GetAllActiveUsers();

        Task Create(Topic topic);
        Task Delete(int topicId);
        Task UpdateTopicTitle(int topicId, string newTitle);
        Task UpdateTopicDescription(int topicId, string newDescription);
    }
}
