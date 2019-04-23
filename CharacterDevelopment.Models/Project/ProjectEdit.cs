namespace CharacterDevelopment.Models.Project
{
    public class ProjectEdit
    {
        public int ProjectId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public byte[] Image { get; set; }
    }
}
