using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ML;
using Microsoft.ML.Data;
using System.IO;

namespace WindowsFormsApp2
{   
    
    public partial class Dispatch : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private bool importFinished = false;
        private bool selectFinished = false;

        // store index of select month, week, year
        private List<int> selectMonth = new List<int>();
        private List<int> selectWeek = new List<int>();
        private List<int> selectYear = new List<int>();
        private int[] selectTime = {0, 24};

        private int runTime = 0;

        public Dispatch()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Dispatch_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Dispatch_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Dispatch_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void Import_button_Click(object sender, EventArgs e)
        {   
            // import call data
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "Please choose the call data.";
            fileDialog.Filter = "(*csv*)|*.csv*"; // filename extension 
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;// return full path      
                Console.WriteLine(file);

                callPath = file;
            }
            else {
                MessageBox.Show("Fail to choose call data", "Message");
                return;
            }

            // import response data
            OpenFileDialog fileDialog1 = new OpenFileDialog();
            fileDialog1.Multiselect = true;
            fileDialog1.Title = "Please choose the response data.";
            fileDialog1.Filter = "(*csv*)|*.csv*"; // filename extension 
            if (fileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog1.FileName;// return full path      
                Console.WriteLine(file);

                responsePath = file;
            }
            else {
                MessageBox.Show("Fail to choose response data", "Message");
                return;
            }

            ml = new MachineLearning();
            ml.Import(callPath, responsePath);

            // // read data from files
            // DataTable callDataTable = CallData.ImportCallData(callPath);
            // DataTable ResponseDataTable = CallData.ImportCallData(responsePath);

            // // combine all data to CallResponseData
            // ana = new AnalyzeData();
            // CallResponseData[] combinedData = ana.CombineData(callDataTable, ResponseDataTable);

            // set label visible to true
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = false;
            label10.Visible = false;

            // shows information on screen
            label1.Text = $"*       Call data file:    {fileDialog.SafeFileName}";
            label2.Text = $"*       Response data file:    {fileDialog1.SafeFileName}";
            label3.Text = $"*       Call count:          {ml.GetAna().callCount}";
            label4.Text = $"*       Nature code type count: {ml.GetAna().NatureCodeTypeNum}";
            label5.Text = $"*       Response unit type: {ml.GetAna().UnitTypeNum}";
            label6.Text = $"*       Bad data count: {ml.GetAna().badDataCount}";
            label7.Text = $"*       Earliest time: {ml.GetAna().dateRange[0].ToString()}";
            label8.Text = $"*       Latest time: {ml.GetAna().dateRange[1].ToString()}";


            // input checkboxlist year
            checkedListBox_year.Items.Clear();
            for (int i=0; i<ml.GetAna().yearCount; i++)
            {
                checkedListBox_year.Items.Add(ml.GetAna().yearList[i],CheckState.Checked);
            }
            // checkedListBox_year.Items.AddRange(ana.yearList);

            // set check box list to checked
            if (checkedListBox_month.Items.Count != 0)
            {
                // loop through all items and check.  
                for (int i = 0; i < checkedListBox_month.Items.Count; i++)
                {
                    checkedListBox_month.SetItemChecked(i, true);
                }
            }

            if (checkedListBox_week.Items.Count != 0)
            {
                // loop through all items and check.   
                for (int i = 0; i < checkedListBox_week.Items.Count; i++)
                {
                    checkedListBox_week.SetItemChecked(i, true);
                }
            }

            
            // set import finish state to true
            importFinished = true;
            selectFinished = false;
        }

        private void Select_button_Click(object sender, EventArgs e)
        {   
            if (importFinished == false){
                MessageBox.Show("Please import data first", "Message");
                return;
            }

            // clear selectMonth
            selectMonth.Clear();

            // save month index to selectMonth
            for (int i=0; i<checkedListBox_month.CheckedIndices.Count; i++)
            {
                selectMonth.Add(checkedListBox_month.CheckedIndices[i]+1);
            }


            // clear selectWeek
            selectWeek.Clear();

            // save month index to selectMonth
            for (int i = 0; i < checkedListBox_week.CheckedIndices.Count; i++)
            {
                selectWeek.Add(checkedListBox_week.CheckedIndices[i]);
            }


            // clear selectYear
            selectYear.Clear();

            // save month index to selectMonth
            for (int i = 0; i < checkedListBox_year.CheckedItems.Count; i++)
            {
                selectYear.Add((int)checkedListBox_year.CheckedItems[i]);
            }

            // set selectTime
            selectTime[0] = trackBar_time_start.Value;
            selectTime[1] = trackBar_time_end.Value;

            if(selectTime[0] >= selectTime[1]){
                MessageBox.Show("Start time should be less than end time", "Alert");
                selectFinished = false;
                return;
            }

            // creat and save train and test tsv file.
            int[] selectItemNum = ml.CreatTsv(selectMonth, selectWeek, selectYear, selectTime);

            label10.Visible = true;
            label10.Text = $"*       Selected items: {selectItemNum[2]}";

            if(selectItemNum[2] == 0) {
                MessageBox.Show("There is no items selected", "Alert");
                selectFinished = false;
                return;
            } else if (selectItemNum[0] < 1000) {
                MessageBox.Show("Train items less than 1000", "Alert");
                selectFinished = false;
                return;
            } else if (selectItemNum[1] < 100) {
                MessageBox.Show("Test items less than 100", "Alert");
                selectFinished = false;
                return;
            }

            // set select finish state to true
            selectFinished = true;

            MessageBox.Show($"Selected", "Message");
        }

        private void Analyse_button_Click(object sender, EventArgs e)
        {   
            // label10.Visible = true;
            // label10.Text = ml.processText;

            if (importFinished == false){
                MessageBox.Show("Please import data first", "Message");
                return;
            }

            if (selectFinished == false){
                MessageBox.Show("Please select data first", "Message");
                return;
            }

            double[] accuracy = ml.ML();

            // set label visible to true and false
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = false;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = false;

            label1.Text = $"*       MicroAccuracy:    {accuracy[0]:0.###}";
            label2.Text = $"*       MacroAccuracy:    {accuracy[1]:0.###}";
            label3.Text = $"*       LogLoss:          {accuracy[2]:0.###}";
            label4.Text = $"*       LogLossReduction: {accuracy[3]:0.###}";
            label6.Text = $"*       Month: {String.Join(", ", selectMonth)}";
            label7.Text = $"*       Week : {String.Join(", ", selectWeek)}";
            label8.Text = $"*       Year : {String.Join(", ", selectYear)}";
            label9.Text = $"*       Time : {String.Join(" - ", selectTime)}";
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Download_Model_Click(object sender, EventArgs e)
        {   
            string message, title, defaultValue;
            string myValue = "rules";

            message = "Please input file name for saving.";
            title = "Saving rules";
            defaultValue = "rules";

            if (inputBox.Show(title, message, defaultValue, ref myValue))
            {
                if (myValue != null)
                {
                    ml.CreatRulesFile(myValue);
                    MessageBox.Show("Saved", "Message");
                    return;
                }
            }

            MessageBox.Show("Failed to save", "Alert");
    
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Min_button_Click(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Minimized;
        }

        private void trackBar_time_start_Scroll(object sender, EventArgs e)
        {
            label_start_time.Text = $"{trackBar_time_start.Value.ToString()}:00";
        }

        private void trackBar_time_end_Scroll(object sender, EventArgs e)
        {
            label_end_time.Text = $"{trackBar_time_end.Value.ToString()}:00";
        }

        // private void Max_button_Click(object sender, EventArgs e)
        // {
        //     this.WindowState = FormWindowState.Maximized;
        // }

    }

    
}
