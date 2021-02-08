using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspForum.Interfaces;
using AspForum.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspForum.Controllers
{
    public class ForumController : Controller
    {
        private readonly ITopic _topicService;
        private readonly IPost _postService;
        public ForumController(ITopic topicService, IPost postService)
        {
            _topicService = topicService;
            _postService = postService;
        }

        public IActionResult Index()
        {
            var topics = _topicService.GetAll()
                .Select(t => new Topic {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Created = t.Created,
                    Posts = t.Posts
                });

            var model = new TopicsListModel
            {
                topicsList = topics
            };

            return View(model);
        }

        public IActionResult Topic(int id)
        {
            var topic = _topicService.GetById(id);
            var posts = _postService.GetPostsForTopic(id);

            var model = new PostsListModel
            {
                postsList = posts,
                topicName = topic.Title
            };

            return View(model);
        }
    }
}
