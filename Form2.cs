using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _151_Coursework
{
    public partial class Form2 : Form
    {

        Location[] globalLocationArray;
        int locationNo, yearNo, radiovalue;

        public Form2(int locationIndex, int yearIndex, int radio)
        {

            InitializeComponent();

            locationNo = locationIndex;
            yearNo = yearIndex;
            radiovalue = radio;

            globalLocationArray = Data.GenerateLocArray("inputEXTENDED.txt");

            if(radiovalue == 0)
            {
                DisplayMax();
            }
            else if(radiovalue == 1)
            {
                DisplayMin();
            }
            else if (radiovalue == 2)
            {
                DisplayDays();
            }
            else if (radiovalue == 3)
            {
                DisplayRain();
            }
            else if (radiovalue == 4)
            {
                DisplaySun();
            }


        }

        private void backbtn_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        public void DisplayMax()
        {

            //declaring all the objects for dislpay
            Location selectedLocation;
            Year selectedYear;
            Month[] arrayofmonths;
            PictureBox[] boxarray = new PictureBox[12];
            Label[] arrayoflabels = new Label[12];

            //declaring variables used to get the data and display the data
            double monthValue;
            double addtoY;
            
            //extracts all the data from the global array
            selectedLocation = globalLocationArray[locationNo];

            selectedYear = globalLocationArray[locationNo].ArrayofYears[yearNo];

            arrayofmonths = selectedYear.MonthlyObs;

            for (int i = 0; i < 12; i++)
            {

                monthValue = arrayofmonths[i].MaxTemp * 10;

                addtoY = monthValue;

                boxarray[i] = new PictureBox();
                boxarray[i].Location = new Point((300 + (i * 30)), (350 - Convert.ToInt32(addtoY)));
                boxarray[i].Size = new Size(25, Convert.ToInt32(monthValue));
                boxarray[i].BackColor = Color.GreenYellow;

                //edits the properties for the max temperature label
                arrayoflabels[i] = new Label();
                arrayoflabels[i].Location = new Point((300 + (i * 30)), 375);
                arrayoflabels[i].Text = $"{arrayofmonths[i].MonthID}";
                arrayoflabels[i].ForeColor = Color.White;
                arrayoflabels[i].Size = new Size(30,30);

                //adds the label and the picturebox
                Controls.Add(arrayoflabels[i]);

                Controls.Add(boxarray[i]);

            }
        }

        public void DisplayMin()
        {

            //declaring all the objects that is used in displaying the max temperature
            Location selectedLocation;
            Year selectedYear;
            Month[] arrayofmonths;
            PictureBox[] boxarray = new PictureBox[12];
            Label[] arrayoflabels = new Label[12];

            //declaring variables used to get the data and display the data
            double monthValue;
            double addtoY;

            //extracts all the data from the global array
            selectedLocation = globalLocationArray[locationNo];

            selectedYear = globalLocationArray[locationNo].ArrayofYears[yearNo];

            arrayofmonths = selectedYear.MonthlyObs;

            for (int i = 0; i < 12; i++)
            {

                monthValue = arrayofmonths[i].MinTemp * 10;

                addtoY = monthValue;

                boxarray[i] = new PictureBox();
                boxarray[i].Location = new Point((300 + (i * 30)), (350 - Convert.ToInt32(addtoY)));
                boxarray[i].Size = new Size(25, Convert.ToInt32(monthValue));
                boxarray[i].BackColor = Color.GreenYellow;

                //instantiates and edits the properties for the max temperature label
                arrayoflabels[i] = new Label();
                arrayoflabels[i].Location = new Point((300 + (i * 30)), 375);
                arrayoflabels[i].Text = $"{arrayofmonths[i].MonthID}";
                arrayoflabels[i].ForeColor = Color.White;
                arrayoflabels[i].Size = new Size(30, 30);

                //adds the label and the picturebox
                Controls.Add(arrayoflabels[i]);

                Controls.Add(boxarray[i]);

            }
        }

        public void DisplayDays()
        {

            //declaring all the objects that is used in displaying the max temperature
            Location selectedLocation;
            Year selectedYear;
            Month[] arrayofmonths;
            PictureBox[] boxarray = new PictureBox[12];
            Label[] arrayoflabels = new Label[12];

            //declaring variables used to get the data and display the data
            double monthValue;
            double addtoY;

            //extracts all the data from the global array
            selectedLocation = globalLocationArray[locationNo];

            selectedYear = globalLocationArray[locationNo].ArrayofYears[yearNo];

            arrayofmonths = selectedYear.MonthlyObs;

            for (int i = 0; i < 12; i++)
            {

                monthValue = arrayofmonths[i].DaysAirFrost * 10;

                addtoY = monthValue;

                boxarray[i] = new PictureBox();
                boxarray[i].Location = new Point((300 + (i * 30)), (350 - Convert.ToInt32(addtoY)));
                boxarray[i].Size = new Size(25, Convert.ToInt32(monthValue));
                boxarray[i].BackColor = Color.GreenYellow;

                //instantiates and edits the properties for the max temperature label
                arrayoflabels[i] = new Label();
                arrayoflabels[i].Location = new Point((300 + (i * 30)), 375);
                arrayoflabels[i].Text = $"{arrayofmonths[i].MonthID}";
                arrayoflabels[i].ForeColor = Color.White;
                arrayoflabels[i].Size = new Size(30, 30);

                //adds the label and the picturebox
                Controls.Add(arrayoflabels[i]);

                Controls.Add(boxarray[i]);

            }
        }

        public void DisplayRain()
        {

            //declaring all the objects that is used in displaying the max temperature
            Location selectedLocation;
            Year selectedYear;
            Month[] arrayofmonths;
            PictureBox[] boxarray = new PictureBox[12];
            Label[] arrayoflabels = new Label[12];

            //declaring variables used to get the data and display the data
            double monthValue;
            double addtoY;

            //extracts all the data from the global array
            selectedLocation = globalLocationArray[locationNo];

            selectedYear = globalLocationArray[locationNo].ArrayofYears[yearNo];

            arrayofmonths = selectedYear.MonthlyObs;

            for (int i = 0; i < 12; i++)
            {

                monthValue = arrayofmonths[i].MMRainfall * 10;

                addtoY = monthValue;

                boxarray[i] = new PictureBox();
                boxarray[i].Location = new Point((300 + (i * 30)), (350 - Convert.ToInt32(addtoY)));
                boxarray[i].Size = new Size(25, Convert.ToInt32(monthValue));
                boxarray[i].BackColor = Color.GreenYellow;

                //instantiates and edits the properties for the max temperature label
                arrayoflabels[i] = new Label();
                arrayoflabels[i].Location = new Point((300 + (i * 30)), 375);
                arrayoflabels[i].Text = $"{arrayofmonths[i].MonthID}";
                arrayoflabels[i].ForeColor = Color.White;
                arrayoflabels[i].Size = new Size(30, 30);

                //adds the label and the picturebox
                Controls.Add(arrayoflabels[i]);

                Controls.Add(boxarray[i]);

            }
        }

        public void DisplaySun()
        {

            //declaring all the objects that is used in displaying the max temperature
            Location selectedLocation;
            Year selectedYear;
            Month[] arrayofmonths;
            PictureBox[] boxarray = new PictureBox[12];
            Label[] arrayoflabels = new Label[12];

            //declaring variables used to get the data and display the data
            double monthValue;
            double addtoY;

            //extracts all the data from the global array
            selectedLocation = globalLocationArray[locationNo];

            selectedYear = globalLocationArray[locationNo].ArrayofYears[yearNo];

            arrayofmonths = selectedYear.MonthlyObs;

            for (int i = 0; i < 12; i++)
            {

                monthValue = arrayofmonths[i].SunshineHours * 10;

                addtoY = monthValue;

                boxarray[i] = new PictureBox();
                boxarray[i].Location = new Point((300 + (i * 30)), (350 - Convert.ToInt32(addtoY)));
                boxarray[i].Size = new Size(25, Convert.ToInt32(monthValue));
                boxarray[i].BackColor = Color.GreenYellow;

                //instantiates and edits the properties for the max temperature label
                arrayoflabels[i] = new Label();
                arrayoflabels[i].Location = new Point((300 + (i * 30)), 375);
                arrayoflabels[i].Text = $"{arrayofmonths[i].MonthID}";
                arrayoflabels[i].ForeColor = Color.White;
                arrayoflabels[i].Size = new Size(30, 30);

                //adds the label and the picturebox
                Controls.Add(arrayoflabels[i]);

                Controls.Add(boxarray[i]);

            }
        }
    }
}