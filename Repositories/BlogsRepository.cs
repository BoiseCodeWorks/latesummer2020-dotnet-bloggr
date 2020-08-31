using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using latesummer2020_dotnet_bloggr.Models;

namespace latesummer2020_dotnet_bloggr.Repositories
{
    public class BlogsRepository
    {
        private readonly IDbConnection _db;

        public BlogsRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Blog> Get()
        {
            string sql = "SELECT * FROM blogs";
            return _db.Query<Blog>(sql);
        }

        public Blog Create(Blog newBlog)
        {
            string sql = @"INSERT INTO blogs
            (title, body, isPublished)
            VALUES
            (@Title, @Body, @IsPublished);
            SELECT LAST_INSERT_ID();";
            newBlog.Id = _db.ExecuteScalar<int>(sql, newBlog);
            return newBlog;
        }

        public Blog GetById(int id)
        {
            string sql = "SELECT * FROM blogs WHERE id = @id;";
            return _db.QueryFirstOrDefault<Blog>(sql, new { id });
        }

        public bool Update(Blog updatedBlog)
        {
            string sql = @"UPDATE blogs 
            SET
                title = @Title,
                body = @Body,
                isPublished = @IsPublished WHERE id = @Id";
            int rows = _db.Execute(sql, updatedBlog);
            return rows > 0;
        }

        public bool Delete(int id)
        {
            string sql = "DELETE FROM blogs WHERE id = @id LIMIT 1;";
            int affectedRows = _db.Execute(sql, new { id });
            return affectedRows == 1;
        }
    }
}