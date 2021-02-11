using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspForum.Interfaces;
using AspForum.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspForum.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopic _topicService;
        private readonly IPost _postService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public TopicController(ITopic topicService,
            IPost postService,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager
            )
        {
            _topicService = topicService;
            _postService = postService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Create()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View(new NewTopicModel());
            }
            else return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewTopicModel model)
        {

            if (ModelState.IsValid)
            {
                Topic topic = CreateTopic(model);

                await _topicService.Create(topic);
                return RedirectToAction("Index", "Forum");
            }
            else return View(model);
        }

        private Topic CreateTopic(NewTopicModel model)
        {
            return new Topic
            {
                //Id = _postService.GetAll().Count() + 1,
                Title = model.Title,
                Description = model.Description,
                Created = DateTime.Now
                               
            };
        }

    }
}
