using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace _151_Coursework
{
    class Data
    {
        public static string SaveFile = "";
           
        public static void FileWrite(string filePath = "")
        {
            if (filePath == "" && SaveFile != "") filePath = SaveFile; //Checkfile has been read & has a file path to save to, used when automatically saving changes


            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(Form1.getLocationArray().Length); //writes number of locations

                for (int i = 0; i < Form1.getLocationArray().Length; i++)

                {
                    sw.WriteLine(Form1.getLocationArray()[i].LocationName);
                    sw.WriteLine(Form1.getLocationArray()[i].LocationStreet);
                    sw.WriteLine(Form1.getLocationArray()[i].LocationCounty);
                    sw.WriteLine(Form1.getLocationArray()[i].LocationPost);
                    sw.WriteLine(Form1.getLocationArray()[i].LocationLatitude);
                    sw.WriteLine(Form1.getLocationArray()[i].LocationLongitude);
                    sw.WriteLine(Form1.getLocationArray()[i].ArrayofYears.Length);



                    for (int j = 0; j < Form1.getLocationArray()[i].ArrayofYears.Length; j++)
                    {
                        sw.WriteLine(Form1.getLocationArray()[i].ArrayofYears[j].YearDesc);


                        for (int k = 0; k < 12; k++)
                        {
                            sw.WriteLine(Form1.getLocationArray()[i].ArrayofYears[j].YearDate); 
                            sw.WriteLine(Form1.getLocationArray()[i].ArrayofYears[j].MonthlyObs[k].MonthID); //j iterating through
                            sw.WriteLine(Form1.getLocationArray()[i].ArrayofYears[j].MonthlyObs[k].MaxTemp);
                            sw.WriteLine(Form1.getLocationArray()[i].ArrayofYears[j].MonthlyObs[k].MinTemp);
                            sw.WriteLine(Form1.getLocationArray()[i].ArrayofYears[j].MonthlyObs[k].DaysAirFrost);
                            sw.WriteLine(Form1.getLocationArray()[i].ArrayofYears[j].MonthlyObs[k].MMRainfall);
                            sw.WriteLine(Form1.getLocationArray()[i].ArrayofYears[j].MonthlyObs[k].SunshineHours);
                        }

                    }
                }
                sw.Close();
            }

        }



        public static Location[] GenerateLocArray(string filePath)
        {
            try//try catch statement to find read errors
            {
                Location[] arrayOfLocations; //initialising arrayoflocations
                using (StreamReader sr = new StreamReader(filePath))
                {
                    int numberOfLocations = Convert.ToInt32(sr.ReadLine());
                    arrayOfLocations = new Location[numberOfLocations];
                    for (int i = 0; i < numberOfLocations; i++)
                    {//gets the data for the location object
                        string locationName = Convert.ToString(sr.ReadLine());
                        string locationSteet = Convert.ToString(sr.ReadLine());
                        string locationCounty = Convert.ToString(sr.ReadLine()); //reads line for line and locates it
                        string locationPost = Convert.ToString(sr.ReadLine());
                        double locationLatitude = Convert.ToDouble(sr.ReadLine());
                        double locationLongitude = Convert.ToDouble(sr.ReadLine());
                        int numberOfYears = Convert.ToInt32(sr.ReadLine());
                        Year[] arrayOfYears = new Year[numberOfYears];// initializing array of years
                        for (int j = 0; j < numberOfYears; j++)
                        {// get data for year object

                            string yearDesc = Convert.ToString(sr.ReadLine());
                            int yearID = Convert.ToInt32(sr.ReadLine());
                            Month[] arrayOfMonths = new Month[12];//initializing month array
                            for (int k = 0; k < 12; k++)
                            {// get data for months object
                                if (k != 0) sr.ReadLine();
                                int monthID = Convert.ToInt32(sr.ReadLine());
                                double maxTemp = Convert.ToDouble(sr.ReadLine());
                                double minTemp = Convert.ToDouble(sr.ReadLine());
                                int daysAirFrost = Convert.ToInt32(sr.ReadLine());
                                double mmRainful = Convert.ToDouble(sr.ReadLine());
                                double sunshineHours = Convert.ToDouble(sr.ReadLine());
                                arrayOfMonths[k] = new Month(monthID, maxTemp, minTemp, daysAirFrost, mmRainful, sunshineHours);// filling arrayofmonths with objects of months
                            }
                            arrayOfYears[j] = new Year(yearID, yearDesc, arrayOfMonths);// filling arrayofyears with year objects
                        }
                        arrayOfLocations[i] = new Location(locationName, locationSteet, locationCounty, locationPost, locationLatitude, locationLongitude, arrayOfYears);//filling arrayoflocations with location objects
                    }
                    SaveFile = filePath;
                }
                return arrayOfLocations;
            }
            catch (Exception ex)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}