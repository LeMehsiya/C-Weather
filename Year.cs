using System;

namespace _151_Coursework
{
    public class Year
    {
        int yearDate;
        string yearDesc;
        Month[] monthlyObs; //define array of months

        public Year(int yearDate, string yearDesc, Month[] monthlyObs)
        {
            this.yearDate = yearDate;
            this.yearDesc = yearDesc;
            this.monthlyObs = monthlyObs;
        }

        //get & setters 

        public int YearDate
        {
            get
            {
                return yearDate;
            }
            set
            {
                yearDate = value;
            }
        }
        public string YearDesc
        {
            get
            {
                return yearDesc;
            }
            set
            {
                yearDesc = value;
            }
        }
        public Month[] MonthlyObs 
        {
            get
            {
                return monthlyObs;
            }
            set
            {
                monthlyObs = value;
            }
        }
    }
}

