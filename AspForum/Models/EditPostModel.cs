using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspForum.Models
{
    public class EditPostModel
    {
        public int postId { get; set; }
        public string newContent { get; set; }
        public int topicId { get; set; }
    }
}
