using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspForum.Models
{
    public class PostsListModel
    {
        public IEnumerable<Post> postsList { get; set; }
        public string topicName { get; set; }
    }
}
