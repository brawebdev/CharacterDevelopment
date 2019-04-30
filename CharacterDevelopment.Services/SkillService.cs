using System;
using System.Collections.Generic;
using System.Linq;
using CharacterDevelopment.Contracts;
using CharacterDevelopment.Data;
using CharacterDevelopment.Models.Skill;

namespace CharacterDevelopment.Services
{
    public class SkillService : ISkillService
    {
        private readonly Guid userId;

        public SkillService(Guid id)
        {
            userId = id;
        }

        public bool CreateSkill(SkillCreate model)
        {
            var entity =
                new Skill
                {
                    OwnerId = userId,
                    SkillId = model.SkillId,
                    Title = model.Title,
                    Description = model.Description,
                    Url = model.Url,
                    Image = model.Image
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Skills.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SkillListItem> GetSkills()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Skills.Select(e => new SkillListItem
                    {
                        Title = e.Title,
                        Description = e.Description,
                        Image = e.Image
                    });

                return query.ToArray();
            }
        }

        public SkillDetail GetSkillById(int skillId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Skills.Single(e => e.SkillId == skillId);

                return new SkillDetail
                {
                    Title = entity.Title,
                    Description = entity.Description,
                    Url = entity.Url,
                    Image = entity.Image
                };
            }
        }

        public bool UpdateSkill(SkillEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Skills.Single(e => e.SkillId == model.SkillId && e.OwnerId == userId);

                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.Url = model.Url;
                entity.Image = model.Image;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSkill(int skillId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Skills.Single(e => e.SkillId == skillId && e.OwnerId == userId);

                ctx.Skills.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
