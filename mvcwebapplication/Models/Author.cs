using mvcwebapplication.Models;
using System.Collections.Generic;
namespace mvcwebapplication.Models
{
    public class Author
    {
        public int id {get;set;}
        public string fName{get;set;}
        public string lName{get;set;}
        public List<BlogPost> BlogPosts {get;set;}
    }
}