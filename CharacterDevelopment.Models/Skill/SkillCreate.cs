using System.ComponentModel.DataAnnotations;

namespace CharacterDevelopment.Models.Skill
{
    public class SkillCreate
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public byte[] Image { get; set; }
    }
}
