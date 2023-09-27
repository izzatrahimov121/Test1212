namespace BigonTask.AppCode.Services
{
    public class DateTimeService:IDateTimeService
    {
        public DateTime ExecutingTime
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
