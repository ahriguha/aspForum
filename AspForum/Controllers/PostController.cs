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
    public class PostController : Controller
    {
        private readonly ITopic _topicService;
        private readonly IPost _postService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public PostController(ITopic topicService,
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

        public IActionResult Create(int id)
        {
            if (_signInManager.IsSignedIn(User))
            {

                var topic = _topicService.GetById(id);

                var model = new NewPostModel
                {
                    topicId = topic.Id,
                    topicName = topic.Title
                };

                return View(model);
            }
            else return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            
                var post = _postService.GetById(id);
            if (_userManager.GetUserId(User) == post.User.Id)
            {
                var model = new EditPostModel
                {
                    postId = post.Id,
                    newContent = post.Content,
                    topicId = post.topic.Id
                };

                return View(model);
            }
            else return RedirectToAction("Topic", "Forum", new { id = post.topic.Id});
            
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewPostModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(_userManager.GetUserId(User));
                Post post = CreatePost(model, user);

                await _postService.Create(post);
                return RedirectToAction("Topic", "Forum", new { id = model.topicId });
            }
            else return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPostModel model)
        {
            if (ModelState.IsValid)
            {
                await _postService.UpdatePostContent(model.postId, model.newContent);
                return RedirectToAction("Topic", "Forum", new { id = model.topicId });
            }
            else return View(model);
        }


        public async Task<IActionResult> DeletePost(int postId)
        {            
            await _postService.Delete(postId);
            return RedirectToAction("Index", "Forum");
        }

        private Post CreatePost(NewPostModel model, IdentityUser user)
        {
            return new Post
            {
                //Id = _postService.GetAll().Count() + 1,
                Title = model.postTitle,
                Content = model.postContent,
                Created = DateTime.Now,
                topic = _topicService.GetById(model.topicId),
                User = user
            };
        }
    }
}
