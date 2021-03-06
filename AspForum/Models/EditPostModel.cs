﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspForum.Models
{
    public class EditPostModel
    {
        public int postId { get; set; }
        [Required]
        public string newContent { get; set; }
        public int topicId { get; set; }
    }
}
