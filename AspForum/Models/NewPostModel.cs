using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspForum.Models
{
    public class NewPostModel
    {
        public string topicName { get; set; }
        public int topicId { get; set; }
        [Required]
        public string postTitle { get; set; }
        [Required]
        public string postContent { get; set; }
         
    }
}
