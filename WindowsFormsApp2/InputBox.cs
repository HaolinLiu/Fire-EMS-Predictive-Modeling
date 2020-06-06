using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class inputBox : Form
    {
        private inputBox()
        {
            InitializeComponent();
        }

        public string getValue()
        {
            return textBox1.Text;
        }

        public static bool Show(string title, string inputTips, string defaultValue, ref String value) 
        {
            inputBox ib = new inputBox();
            
            if (title != null)
            {
                ib.Text = title;
            }

            if (inputTips != null)
            {
                ib.label1.Text = inputTips;
            }
        
            if (ib.ShowDialog()==DialogResult.OK)
            {
                value = ib.getValue();
                ib.Dispose();
                return true;
            }
            else
            {
                ib.Dispose();
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
