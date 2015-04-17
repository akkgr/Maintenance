using System;

namespace Recurrence
{
    public class DailyRecurrenceType : IRecurrenceType
    {
        public DateTime GetOccurrence(DateTime startDate, int occurrenceNumber)
        {
            return startDate.AddDays(occurrenceNumber*1);
        }
    }
}
