using System;
using System.ComponentModel.DataAnnotations;

namespace CharacterDevelopment.Data
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

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
