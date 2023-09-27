namespace BigonTask.Models.Entities.Commons
{
    public interface IAuditableEntity
    {
        int CreatedBy { get; set; }
         DateTime CreatedAt { get; set; }
       int? DeletedBy { get; set; }
         DateTime? DeletedAt { get; set; }
         int? LastModifiedBy { get; set; }
         DateTime? LastModifiedAt { get; set; }
    }
}
