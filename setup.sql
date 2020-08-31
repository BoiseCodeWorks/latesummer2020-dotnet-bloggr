-- CREATE TABLE blogs (
--     id INT NOT NULL AUTO_INCREMENT,
--     title VARCHAR(80),
--     body VARCHAR(255),
--     description VARCHAR(255),
--     isPublished TINYINT NOT NULL,
--     PRIMARY KEY (id)
-- )

-- ALTER TABLE blogs DROP description

-- INSERT INTO blogs (
--     title,
--     body,
--     isPublished
-- ) 
-- VALUES(
--     "New blog",
--     "Whatevessss",
--     true
-- )

-- CREATE TABLE comments (
--     id INT NOT NULL AUTO_INCREMENT,
--     body VARCHAR(255),
--     blogId INT NOT NULL,
--     PRIMARY KEY (id),

--     INDEX(blogId),

--     FOREIGN KEY(blogId)
--     REFERENCES blogs(id)
--     ON DELETE CASCADE
-- )


SELECT * FROM blogs
