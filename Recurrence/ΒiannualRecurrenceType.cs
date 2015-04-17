using System;

namespace Recurrence
{
    public class ΒiannualRecurrenceType : IRecurrenceType
    {
        public DateTime GetOccurrence(DateTime startDate, int occurrenceNumber)
        {
            return startDate.AddMonths(6*occurrenceNumber);
        }
    }
}
