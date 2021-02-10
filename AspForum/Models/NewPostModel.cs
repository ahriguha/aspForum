using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspForum.Models
{
    public class NewPostModel
    {
        public string topicName { get; set; }
        public int topicId { get; set; }
        public string postTitle { get; set; }
        public string postContent { get; set; }
         
    }
}
