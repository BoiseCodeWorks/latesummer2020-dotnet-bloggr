using System;
using System.Collections.Generic;
using latesummer2020_dotnet_bloggr.Models;
using latesummer2020_dotnet_bloggr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace latesummer2020_dotnet_bloggr.Services
{
    public class CommentsService
    {
        private readonly CommentsRepository _repo;

        public CommentsService(CommentsRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Comment> Get()
        {
            return _repo.Get();
        }

        public Comment Create(Comment newComment)
        {
            return _repo.Create(newComment);
        }
        public IEnumerable<Comment> GetCommentsByBlogId(int id)
        {
            return _repo.GetCommentsByBlogId(id);
        }
    }
}