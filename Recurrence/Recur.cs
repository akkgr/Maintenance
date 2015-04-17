namespace Recurrence
{
    public static class Recur
    {
        public static OccurrenceEnumerable Daily()
        {
            return new OccurrenceEnumerable(new DailyRecurrenceType());
        }

        public static OccurrenceEnumerable Weekly()
        {
            return new OccurrenceEnumerable(new WeeklyRecurrenceType());
        }

        public static OccurrenceEnumerable Monthly()
        {
            return new OccurrenceEnumerable(new MonthlyRecurrenceType());
        }

        public static OccurrenceEnumerable Quarterly()
        {
            return new OccurrenceEnumerable(new QuarterlyRecurrenceType());
        }

        public static OccurrenceEnumerable Βiannual()
        {
            return new OccurrenceEnumerable(new ΒiannualRecurrenceType());
        }

        public static OccurrenceEnumerable Yearly()
        {
            return new OccurrenceEnumerable(new YearlyRecurrenceType());
        }
    }
}
