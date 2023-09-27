using BigonTask.Models.Entities.Commons;

namespace BigonTask.Models.Entities
{
    public class Subscriber:AuditableEntity
    {
        public string Email { get; set; }
        public bool Approved { get; set; }
    
        public DateTime? ApprovedAt { get; set; }

    }
}
