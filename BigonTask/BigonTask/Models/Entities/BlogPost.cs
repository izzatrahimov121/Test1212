using BigonTask.Models.Entities.Commons;

namespace BigonTask.Models.Entities
{
    public class BlogPost : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImagePath { get; set; }
        public string Slug { get; set; }
        public int CategoryId { get; set; }
        public DateTime? PublishedAt { get; set; }
    }
}
