using BigonTask.Models.Entities.Commons;

namespace BigonTask.Models.Entities
{
    public class ContactPost:BaseEntity<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Answer { get; set; }
        public int? AnsweredBy { get; set; }
        public DateTime? AnsweredAt { get; set; }
    }
}
