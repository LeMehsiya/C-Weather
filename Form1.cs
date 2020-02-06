using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace _151_Coursework
{
    public partial class Form1 : Form
    {
        static Location[] arrayLoc;

        public static Location[] getLocationArray()
        {
            return arrayLoc;
        }

        public Form1()
        {
            InitializeComponent();
        }


        private void btnReadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                arrayLoc = Data.GenerateLocArray(openFileDialog1.FileName);
                for (int i = 0; i < arrayLoc.Length; i++)
                {
                    locationSelect.Items.Add(arrayLoc[i].LocationName);
                }
                locationSelect.SelectedIndex = 0;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        ///////////////////yearselect//////////////////////
        {

            GridOfData.Rows.Clear();
            for (int i = 0; i < 12; i++)
            {

                int year = arrayLoc[locationSelect.SelectedIndex].ArrayofYears[YearSelect.SelectedIndex].YearDate;
                int month = arrayLoc[locationSelect.SelectedIndex].ArrayofYears[YearSelect.SelectedIndex].MonthlyObs[i].MonthID;
                double maxTemp = arrayLoc[locationSelect.SelectedIndex].ArrayofYears[YearSelect.SelectedIndex].MonthlyObs[i].MaxTemp;
                double mintemp = arrayLoc[locationSelect.SelectedIndex].ArrayofYears[YearSelect.SelectedIndex].MonthlyObs[i].MinTemp;
                int daysAirFrost = arrayLoc[locationSelect.SelectedIndex].ArrayofYears[YearSelect.SelectedIndex].MonthlyObs[i].DaysAirFrost;
                double mmRain = arrayLoc[locationSelect.SelectedIndex].ArrayofYears[YearSelect.SelectedIndex].MonthlyObs[i].MMRainfall;
                double sun = arrayLoc[locationSelect.SelectedIndex].ArrayofYears[YearSelect.SelectedIndex].MonthlyObs[i].SunshineHours;

                GridOfData.Rows.Add(year, month, maxTemp, mintemp, daysAirFrost, mmRain, sun);
            }


        }

        private void GridOfData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /////////////////////location box///////////////////////
            ///
            YearSelect.Items.Clear();
            GridOfData.Rows.Clear();
            for (int i = 0; i < arrayLoc[locationSelect.SelectedIndex].ArrayofYears.Length; i++)
            {
                YearSelect.Items.Add(arrayLoc[locationSelect.SelectedIndex].ArrayofYears[i].YearDate);
            }
            YearSelect.SelectedIndex = 0;
            //puts data to textboxes
            dspLocName.Text = arrayLoc[locationSelect.SelectedIndex].LocationName.ToString();
            dspStInfo.Text = arrayLoc[locationSelect.SelectedIndex].LocationStreet.ToString();
            dspCounty.Text = arrayLoc[locationSelect.SelectedIndex].LocationCounty.ToString();
            dspPostCode.Text = arrayLoc[locationSelect.SelectedIndex].LocationPost.ToString();
            dspLatitude.Text = arrayLoc[locationSelect.SelectedIndex].LocationLatitude.ToString();
            dspLongitude.Text = arrayLoc[locationSelect.SelectedIndex].LocationLongitude.ToString();

            dspYear.Text = arrayLoc[locationSelect.SelectedIndex].ArrayofYears[YearSelect.SelectedIndex].YearDate.ToString();
            dspYearDesc.Text = arrayLoc[locationSelect.SelectedIndex].ArrayofYears[YearSelect.SelectedIndex].YearDesc.ToString();
        }

        private void dspLocName_TextChanged(object sender, EventArgs e)
        {
        }
        private void dspStInfo_TextChanged(object sender, EventArgs e)
        {
        }
        private void dspCounty_TextChanged(object sender, EventArgs e)
        {
        }
        private void dspPostCode_TextChanged(object sender, EventArgs e)
        {
        }
        private void dspLatitude_TextChanged(object sender, EventArgs e)
        {
        }
        private void dspLongitude_TextChanged(object sender, EventArgs e)
        {
        }
        private void dspYear_TextChanged(object sender, EventArgs e)
        {
        }
        private void dspYearDesc_TextChanged(object sender, EventArgs e)
        {
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (.txt)|.txt|All files (.)|.";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Data.FileWrite(saveFileDialog.FileName);
            }
        }

        private void GridOfData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (arrayLoc != null)
            {
                arrayLoc[locationSelect.SelectedIndex].ArrayofYears[YearSelect.SelectedIndex].MonthlyObs = getMonthArray();
                Data.FileWrite();
            }                 
        }

        private Month[] getMonthArray()
        {
            Month[] months = new Month[12];
            foreach(DataGridViewRow row in GridOfData.Rows) //turns the data grid array into an array of months
            {
                if (row.Index < 12)
                {
                    int month = row.Index + 1;
                    months[month - 1] = new Month(month, Convert.ToDouble(row.Cells["MaxTemp"].Value.ToString()), Convert.ToDouble(row.Cells["MinTemp"].Value.ToString()), Convert.ToInt32(row.Cells["DaysOfFrost"].Value.ToString()), Convert.ToDouble(row.Cells["mmRainfall"].Value.ToString()), Convert.ToDouble(row.Cells["SunshineHours"].Value.ToString()));
                }
            }
            return months;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            arrayLoc[locationSelect.SelectedIndex].LocationName = dspLocName.Text; //update the currently select location and year
            arrayLoc[locationSelect.SelectedIndex].LocationStreet = dspStInfo.Text;
            arrayLoc[locationSelect.SelectedIndex].LocationCounty = dspCounty.Text;
            arrayLoc[locationSelect.SelectedIndex].LocationPost = dspPostCode.Text;
            arrayLoc[locationSelect.SelectedIndex].LocationLatitude = Convert.ToDouble(dspLatitude.Text);
            arrayLoc[locationSelect.SelectedIndex].LocationLongitude = Convert.ToDouble(dspLongitude.Text);
            arrayLoc[locationSelect.SelectedIndex].ArrayofYears[YearSelect.SelectedIndex].YearDesc = dspYearDesc.Text;
            Data.FileWrite();
        }

        private void btnAddYear_Click(object sender, EventArgs e)
        {

            Month[] temp = new Month[12];
            Year tempyr;
            Year[] copy = new Year[arrayLoc[locationSelect.SelectedIndex].ArrayofYears.Length + 1]; //makes array 1 size bigger

            //copies everything over
            for(int n = 0; n < arrayLoc[locationSelect.SelectedIndex].ArrayofYears.Length; n++)
            {
                copy[n] = arrayLoc[locationSelect.SelectedIndex].ArrayofYears[n];
            }

            //create empty year
            for(int i = 0; i <12; i++)
            {
                temp[i] = new Month(i,0,0,0,0,0);
            }

            tempyr = new Year(0, "empty", temp);

            copy[copy.Length - 1] = tempyr;

            arrayLoc[locationSelect.SelectedIndex].ArrayofYears = copy;

            YearSelect.Items.Add(copy[copy.Length - 1].YearDate);

        }

        private void btnAddLoc_Click(object sender, EventArgs e)
        {

            Location[] temparray = new Location[arrayLoc.Length + 1]; //creates copy of array with 1 size up
            Month[] temp = new Month[12];
            Year[] yeararray = new Year[1];
            Location tempLocation;
            Year tempyr;

            //copies the location array
            for (int i = 0; i < arrayLoc.Length; i++)
            {
                temparray[i] = arrayLoc[i];
            }
            
            //create empty year
            for (int i = 0; i < 12; i++)
            {
                temp[i] = new Month(i, 0, 0, 0, 0, 0);
            }

            tempyr = new Year(0, "empty", temp); //creates empty year
            
            yeararray[0] = tempyr; //sets empty year to empty year array

            tempLocation = new Location("empty", "empty", "empty", "empty", 0, 0, yeararray); //creates new location with empty values

            temparray[temparray.Length - 1] = tempLocation;

            arrayLoc = temparray; //sets the location array to main variable -> arrayLoc

            locationSelect.Items.Add(arrayLoc[arrayLoc.Length - 1].LocationName); //add location to box

        }
        // graph buttons
        int radiovalue = 0;
        private void max_CheckedChanged(object sender, EventArgs e)
        {
            radiovalue = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radiovalue = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            radiovalue = 2;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            radiovalue = 3;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            radiovalue = 4;
        }

        private void graphbutton_Click(object sender, EventArgs e)
        {

            Form2 loadform = new Form2(locationSelect.SelectedIndex, YearSelect.SelectedIndex, radiovalue);

            loadform.Show(); //creates graph

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}

