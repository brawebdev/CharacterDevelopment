using System.Collections.Generic;
using CharacterDevelopment.Models.Skill;

namespace CharacterDevelopment.Contracts
{
    public interface ISkillService
    {
        bool CreateSkill(SkillCreate model);
        IEnumerable<SkillListItem> GetSkills();
        SkillDetail GetSkillById(int skillId);
        bool UpdateSkill(SkillEdit model);
        bool DeleteSkill(int skillId);
    }
}
