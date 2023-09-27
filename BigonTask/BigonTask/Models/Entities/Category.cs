using BigonTask.Models.Entities.Commons;

namespace BigonTask.Models.Entities
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }
        public int ParentId { get; set; }
    }
}
