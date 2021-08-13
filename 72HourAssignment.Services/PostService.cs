using _72HourAssignment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace _72HourAssignment.Services
{
    public class PostService
    {
        private readonly Guid _AuthorId;

        public PostService(Guid authorId)
        {
            _AuthorId = authorId;
        }

        public bool CreatePost(Post model)
        {
            var entity =
                new Post()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Text = model.Text,
                    AuthorId = _AuthorId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<Post> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    .Where(e => e.AuthorId == _AuthorId)
                    .Select(
                        e =>
                        new Post
                        {
                            Id = e.Id,
                            Title = e.Title,
                            Text = e.Text,
                            AuthorId = _AuthorId,
                        }
                    );
                return query.ToArray();
            }
        }

        public Post GetPostById(int id, Guid AuthorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.Id == id && e.AuthorId == _AuthorId);
                return
                    new Post
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Text = entity.Text,
                        AuthorId = _AuthorId,

                    };
            }
        }

        public bool UpdateNote(Post model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.Id == model.Id && e.AuthorId == _AuthorId);

                entity.Id = model.Id;
                entity.Title = model.Title;
                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.Id == Id && e.AuthorId == _AuthorId);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

