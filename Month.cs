using System;

namespace _151_Coursework
{
    public class Month
    {
        double maxTemp;
        double minTemp;
        int daysAirFrost;
        double mmRainfall;
        double sunshineHours;
        int monthID;

        public Month(int monthID,double maxTemp, double minTemp, int daysAirFrost, double mmRainfall, double sunshineHours)
        {
            this.monthID = monthID;
            this.maxTemp = maxTemp;
            this.minTemp = minTemp;
            this.daysAirFrost = daysAirFrost;
            this.mmRainfall = mmRainfall;
            this.sunshineHours = sunshineHours;
        }

        public double MaxTemp
        {
            get
            {
                return maxTemp;
            }
            set
            {
                maxTemp = value;
            }
        }
        public double MinTemp
        {
            get
            {
                return minTemp;
            }
            set
            {
                minTemp = value;
            }
        }
        public int DaysAirFrost
        {
            get
            {
                return daysAirFrost;
            }
            set
            {
                daysAirFrost = value;
            }
        }
        public double MMRainfall
        {
            get
            {
                return mmRainfall;
            }
            set
            {
                mmRainfall = value;
            }
        }
        public double SunshineHours
        {
            get
            {
                return sunshineHours;
            }
            set
            {
                sunshineHours = value;
            }
        }

        public int MonthID
        {
            get
            {
                return monthID;
            }
            set
            {
                monthID = value;
            }
        }
    }

}
