using System;
using System.ComponentModel.DataAnnotations;

namespace CharacterDevelopment.Models.Post
{
    public class PostDetail
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{PostId}] {Title}";
    }
}
