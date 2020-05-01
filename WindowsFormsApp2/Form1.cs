/*
 * @Author: Haolin Liu
 * @Date: 2020-02-16 01:44:33
 * @LastEditTime: 2020-04-30 17:32:41
 * @LastEditors: Haolin Liu
 * @Description: Make functions for buttons in software windows
 */
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

            OpenFileDialog fileDialog1 = new OpenFileDialog();
            fileDialog1.Multiselect = true;
            fileDialog1.Title = "Please choose the call data.";
            fileDialog1.Filter = "(*csv*)|*.csv*"; // filename extension 
            if (fileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog1.FileName;// return full path      
                Console.WriteLine(file);

                responsePath = file;
            }

            DataTable callDataTable = CallData.ImportCallData(callPath);
            DataTable ResponseDataTable = CallData.ImportCallData(responsePath);

            AnalyzeData ana = new AnalyzeData();
            CallResponseData[] combinedData = ana.CombineData(callDataTable, ResponseDataTable);

            label1.Text = $"*       Call data file:    {fileDialog.SafeFileName}";
            label2.Text = $"*       Response data file:    {fileDialog1.SafeFileName}";
            label3.Text = $"*       Call numbers:          {ana.callCount}";
            label4.Text = $"*       Nature code type numbers: {ana.NatureCodeTypeNum}";
            label5.Text = $"*       Response unit type: {ana.UnitTypeNum}";
        }

        private void Analyse_button_Click(object sender, EventArgs e)
        {
            
            MachineLearning ml = new MachineLearning();
            double[] accuracy = ml.ML(callPath, responsePath);

            label1.Text = $"*       MicroAccuracy:    {accuracy[0]:0.###}";
            label2.Text = $"*       MacroAccuracy:    {accuracy[1]:0.###}";
            label3.Text = $"*       LogLoss:          {accuracy[2]:0.###}";
            label4.Text = $"*       LogLossReduction: {accuracy[3]:0.###}";
            label5.Visible = false;
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
            MessageBox.Show("Model saved on \"Models\"", "Message");
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Min_button_Click(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Minimized;
        }

        private void Max_button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rules saved on \"Data\"", "Message");
        }
    }
}
