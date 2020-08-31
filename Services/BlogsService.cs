using System;
using System.Collections.Generic;
using latesummer2020_dotnet_bloggr.Models;
using latesummer2020_dotnet_bloggr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace latesummer2020_dotnet_bloggr.Services
{
    public class BlogsService
    {
        private readonly BlogsRepository _repo;

        public BlogsService(BlogsRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Blog> Get()
        {
            return _repo.Get();
        }

        public Blog Create(Blog newBlog)
        {
            return _repo.Create(newBlog);
        }

        public Blog GetById(int id)
        {
            Blog foundBlog = _repo.GetById(id);
            if (foundBlog == null)
            {
                throw new Exception("No blog by that ID");
            }
            return foundBlog;
        }

        public Blog Update(int id, Blog updatedBlog)
        {
            Blog foundBlog = GetById(id);
            updatedBlog.Id = id;
            updatedBlog.Title = updatedBlog.Title == null ? foundBlog.Title : updatedBlog.Title;
            updatedBlog.Body = updatedBlog.Body == null ? foundBlog.Body : updatedBlog.Body;
            if (_repo.Update(updatedBlog))
            {
                return updatedBlog;
            }
            throw new Exception("Oops something went wrong. The update failed.");
        }

        public string Delete(int id)
        {
            Blog foundBlog = GetById(id);
            if (_repo.Delete(id))
            {
                return "Great Success, Delorted.";
            }
            throw new Exception("Yeah, no, that didnt work.");
        }
    }
}