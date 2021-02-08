using AspForum.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspForum.Interfaces
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetPostsForTopic(int topicId);
        
        Task Create(Post post);
        Task Delete(int postId);
        Task UpdatePostTitle(int postId, string newTitle);
        Task UpdatePostContent(int postId, string newContent);
    }
}
