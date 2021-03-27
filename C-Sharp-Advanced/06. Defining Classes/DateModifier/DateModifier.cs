using System;

namespace DateModifier
{
    public class DateModifier
    {
        private string firstDate;
        private string secondDate;
        
        public DateModifier(string firstDate, string secondDate)
        {
            this.firstDate = firstDate;
            this.secondDate = secondDate;
        }

        public double GetDaysDifference()
        {
            DateTime first = DateTime.Parse(firstDate);
            DateTime second = DateTime.Parse(secondDate);

            double differenceDays = (first - second).TotalDays;
            differenceDays = Math.Abs(differenceDays);
            return differenceDays;
        }
    }
}