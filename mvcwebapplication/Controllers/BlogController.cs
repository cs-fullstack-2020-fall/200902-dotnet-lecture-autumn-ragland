using Microsoft.AspNetCore.Mvc;
using mvcwebapplication.Dao;
using mvcwebapplication.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace mvcwebapplication.Controllers
{
    public class Blog : Controller
    {
        private readonly MvcWebApplicationDbContext _context;
        public Blog(MvcWebApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return Content("Hiya");
        }
        [HttpPost]
        public IActionResult AddAuthor(string fName, string lName)
        {
            Author newAuthor = new Author(){fName = fName, lName = lName};
            _context.Authors.Add(newAuthor);
            _context.SaveChanges();
            return Content($"Created author {newAuthor.fName}");
        }
        [HttpPost]
        public IActionResult AddPost(int authorID, string newTitle, string newText, int newRating)
        {
            Author matchingAuthor = _context.Authors.Include(a => a.BlogPosts).FirstOrDefault(a => a.id == authorID);
            BlogPost newPost = new BlogPost(){title = newTitle, text = newText, rating = newRating};
            matchingAuthor.BlogPosts.Add(newPost);
            _context.BlogPosts.Add(newPost);
            _context.SaveChanges();
            return Content($"Created {newPost.title}"); 
            
        }
        public IActionResult ListPosts()
        {
            string displayStr = "";
            foreach(BlogPost post in _context.BlogPosts)
            {
                displayStr += $"ID : {post.id}\nTitle : {post.title}\nText : {post.text}\nRating : {post.rating}\n";
            }
            return Content(displayStr);
        }
        public IActionResult ListAuthors()
        {
            List<Author> authorList = _context.Authors.Include(a => a.BlogPosts).ToList();
            string displayStr = "";
            foreach(Author author in authorList)
            {
                displayStr += $"ID : {author.id}\nF Name : {author.fName}\nL Name : {author.lName}\nPosts : ";
                foreach(BlogPost post in author.BlogPosts)
                {
                    displayStr += $"ID : {post.id}\nTitle : {post.title}\nText : {post.text}\nRating : {post.rating}\n";
                }
            }
            return Content(displayStr);
        }
    }
}