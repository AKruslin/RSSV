using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zad2_lab
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer t;
        DateTime alarm;

        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.MinDate = DateTime.Now;
            t = new System.Timers.Timer(1000);
            t.Elapsed += new System.Timers.ElapsedEventHandler(ticker);

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (t.Enabled == false)
            {
                t.Start();
                button1.Text = "Zaustavi";
                alarm = dateTimePicker1.Value;
            }
            else
            {
                t.Stop();
                button1.Text = "Pokreni";
                alarm = DateTime.MaxValue;
            }
        }

        private void ticker(object s, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                label1.Text = "Odbrojavanje: "+(alarm -DateTime.Now);
                if (DateTime.Now >= alarm)
                {
                    Console.Beep();
                }
            });
        }

        
    }
}
