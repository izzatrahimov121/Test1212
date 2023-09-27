using BigonTask.Models.Entities.Commons;

namespace BigonTask.Models.Entities
{
    public class Faq:BaseEntity<int>
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
