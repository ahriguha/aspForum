using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspForum.Models
{
    public class TopicsListModel
    {
        public IEnumerable<Topic> topicsList { get; set; }
    }
}
