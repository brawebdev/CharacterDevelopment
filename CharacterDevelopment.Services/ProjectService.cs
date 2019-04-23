﻿using System;
using System.Collections.Generic;
using System.Linq;
using CharacterDevelopment.Data;
using CharacterDevelopment.Models.Project;

namespace CharacterDevelopment.Services
{
    public class ProjectService
    {
        private readonly Guid _userId;

        public ProjectService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProject(ProjectCreate model)
        {
            var entity =
                new Project
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Description = model.Description,
                    Url = model.Url,
                    Image = model.Image
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Projects.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProjectListItem> GetProjects()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Projects.Select(e => new ProjectListItem
                    {
                        Title = e.Title,
                        Description = e.Description,
                        Image = e.Image
                    });

                return query.ToArray();
            }
        }

        public ProjectDetail GetProjectById(int projectId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Projects.Single(e => e.ProjectId == projectId);

                return new ProjectDetail
                {
                    Title = entity.Title,
                    Description = entity.Description,
                    Url = entity.Url,
                    Image = entity.Image
                };
            }
        }

        public bool UpdateProject(ProjectEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Projects.Single(e => e.ProjectId == model.ProjectId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.Url = model.Url;
                entity.Image = model.Image;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProject(int projectId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Projects.Single(e => e.ProjectId == projectId && e.OwnerId == _userId);

                ctx.Projects.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
