﻿using System;
using System.Collections.Generic;
using System.Linq;
using CharacterDevelopment.Contracts;
using CharacterDevelopment.Data;
using CharacterDevelopment.Models.Post;

namespace CharacterDevelopment.Services
{
    public class PostService : IPostService
    {
        private readonly Guid userId;
        private readonly IApplicationDbContext context = new ApplicationDbContext();

        public PostService(Guid inputUserId)
        {
            userId = inputUserId;
        }

        public PostService(IApplicationDbContext mockContext)
        {
            context = mockContext;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post
                {
                    OwnerId = userId,
                    Title = model.Title,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = context)
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = context)
            {
                var query =
                    ctx.Posts.Select(e => new PostListItem
                    {
                        PostId = e.PostId,
                        Title = e.Title,
                        CreatedUtc = e.CreatedUtc
                    });

                return query.ToArray();
            }
        }

        public PostDetail GetPostById(int postId)
        {
            using (var ctx = context)
            {
                var entity = 
                    ctx.Posts.Single(e => e.PostId == postId);
                return new PostDetail
                {
                    PostId = entity.PostId,
                    Title = entity.Title,
                    Content = entity.Content,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }

        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = context)
            {
                var entity = ctx.Posts.Single(e => e.PostId == model.PostId && e.OwnerId == userId);

                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                ctx.MarkAsModified(model);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int postId)
        {
            using (var ctx = context)
            {
                var entity = ctx.Posts.Single(e => e.PostId == postId && e.OwnerId == userId);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}