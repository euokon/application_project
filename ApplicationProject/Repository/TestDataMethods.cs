using ApplicationProject.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationProject.Repository
{
    public class TestDataMethods : ITestDataMethods
    {

        public double DateRangeValue(DateTime startDate, DateTime endDate)
        {
            double workDays = 0;
            //double numberOfDays = (endDate - startDate).TotalDays;
            //DateTime lastDay = startDate.AddDays(numberOfDays);

            while (startDate != endDate)
            {
                if (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    workDays++;
                }
                startDate = startDate.AddDays(1);
            }
            return workDays;
        }

    }
}
