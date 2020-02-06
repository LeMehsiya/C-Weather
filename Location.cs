using System;

namespace _151_Coursework
{
    public class Location
    {
        string locationName;
        string locationStreet;
        string locationCounty;
        string locationPost;
        double locationLatitude;
        double locationLongitude;
        Year[] arrayOfYears;
        
        public Location(string locationName, string locationStreet, string locationCounty, string locationPost, double locationLatitude, double locationLongitude, Year[] arrayOfYears)
        {
            this.locationName = locationName;
            this.locationStreet = locationStreet;
            this.locationCounty = locationCounty;
            this.locationPost = locationPost;
            this.locationLatitude = locationLatitude;
            this.locationLongitude = locationLongitude;
            this.arrayOfYears = arrayOfYears;
        }

        public string LocationName
        {
            get
            {
                return locationName;
            }
            set
            {
                locationName = value;
            }
        }
        public string LocationStreet
        {
            get
            {
                return locationStreet;
            }
            set
            {
                locationStreet = value;
            }
        }
        public string LocationCounty
        {
            get
            {
                return locationCounty;
            }
            set
            {
                locationCounty = value;
            }
        }
        public string LocationPost
        {
            get
            {
                return locationPost;
            }
            set
            {
                locationPost = value;
            }
        }
        public double LocationLatitude
        {
            get
            {
                return locationLatitude;
            }
            set
            {
                locationLatitude = value;
            }
        }
        public double LocationLongitude
        {
            get
            {
                return locationLongitude;
            }
            set
            {
                locationLongitude = value;
            }
        }
        public Year[] ArrayofYears
        {
            get
            {
                return arrayOfYears;
            }
            set
            {
                arrayOfYears = value;
            }
        }

    }
}
