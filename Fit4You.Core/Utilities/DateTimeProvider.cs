using System;
using System.Collections.Generic;
using System.Text;

namespace Fit4You.Core.Utilities
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DayOfWeek DayOfWeek()
        {
            return DateTime.Now.DayOfWeek;
        }
    }
}
