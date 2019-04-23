namespace CharacterDevelopment.Models.Skill
{
    public class SkillEdit
    {
        public int ProjectId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public byte[] Image { get; set; }
    }
}
