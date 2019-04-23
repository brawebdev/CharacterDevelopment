using System;
using System.ComponentModel.DataAnnotations;

namespace CharacterDevelopment.Models.Post
{
    public class PostListItem
    {
        public int PostId { get; set; }
        public string Title { get; set; }

        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public override string ToString() => Title;
    }
}
