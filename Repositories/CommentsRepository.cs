using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using latesummer2020_dotnet_bloggr.Models;

namespace latesummer2020_dotnet_bloggr.Repositories
{
    public class CommentsRepository
    {
        private readonly IDbConnection _db;

        public CommentsRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Comment> Get()
        {
            string sql = "SELECT * FROM comments";
            return _db.Query<Comment>(sql);
        }

        public Comment Create(Comment newComment)
        {
            string sql = @"INSERT INTO comments
            (body, blogId)
            VALUES
            (@Body, @blogId);
            SELECT LAST_INSERT_ID();";
            newComment.Id = _db.ExecuteScalar<int>(sql, newComment);
            return newComment;
        }

        public IEnumerable<Comment> GetCommentsByBlogId(int id)
        {
            string sql = "SELECT * FROM comments WHERE blogId = @id";
            return _db.Query<Comment>(sql, new { id });
        }
    }
}