using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string see = "Not Do Anything";
        int time = 0;
        int check = 0;
        
        public Form1()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            see = "Shutdown";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            see = "Hibernate";
        }

        private async Task tAsync(int ti, string see)
        {
            await Task.Delay(ti*60000);

            if (see == "Shutdown")
            {
                System.Diagnostics.Process.Start("shutdown", "/s /t 0");
                System.Windows.Forms.Application.Exit();
            }
            else if (see == "Hibernate")
            {
                Application.SetSuspendState(PowerState.Hibernate, true, true);
                System.Windows.Forms.Application.Exit();
            }
            else if (see == "Sleep")
            {
                Application.SetSuspendState(PowerState.Suspend, true, true);
                System.Windows.Forms.Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool wreck = true;
            if (check == 0)
            {
                string word = null;
                wreck = true;
                check = 1;
                button3.Enabled = false;
                if(time == 0)
                {
                    word = " NOT ";
                }
                textBox2.Text = "Rest Assured, Your Computer Will " + word + see + " In " + time + " Minutes";
                if (time == 0 || see == "Not Do Anything")
                {
                    button3.Enabled = true;
                    check = 0;
                    wreck = false;
                    word = null;
                }

                if (wreck)
                {
                    tAsync(time, see);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(textBox3.Text, out n);
            if (!String.IsNullOrEmpty(textBox3.Text) && isNumeric)
            time = Convert.ToInt32(textBox3.Text);

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            see = "Sleep";
        }

        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
