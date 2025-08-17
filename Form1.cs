using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyProject3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            nudTime.Value = 10;
            nudNumberOfQuestion.Value = 3;
            cbLevel.SelectedIndex = 0;
            cbOperation.SelectedIndex = 0;

        }

         
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            Form frm1 = new MathGame(tbPlayer.Text,nudTime.Value.ToString(),nudNumberOfQuestion.Value.ToString(),
                cbLevel.Text,cbOperation.Text);
            frm1.ShowDialog();

           
        }

        void InitialValues()
        {
            
        }

        private void nudNumberOfQuestion_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void nudTime_ValueChanged(object sender, EventArgs e)
        {
           
        }
    }
}
