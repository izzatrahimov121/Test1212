using BigonTask.Models.Entities.Commons;

namespace BigonTask.Models.Entities
{
    public class Size:BaseEntity<int>
    {
        public string Name { get; set; }
        public string SmallName { get; set; }
    }
}
