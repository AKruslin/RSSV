using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Zad1_lab
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer t;
        private int counter = 0;
        StreamReader citac;
        int[] valueArray;
        public Form1()
        {
            InitializeComponent();
            t = new System.Timers.Timer(1000);
            t.Elapsed += new System.Timers.ElapsedEventHandler(vrijeme);
            citac = new StreamReader("value.txt");
            valueArray =
               Array.ConvertAll(citac.ReadLine().Split(',').ToArray(), int.Parse);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (t.Enabled == false)
            {
                t.Start();
                button1.Text = "Zaustavi";
            }
            else
            {
                t.Stop();
                button1.Text = "Pokreni";
            }
        }
        private void vrijeme(object s, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
            int criticalValue = Int32.Parse(richTextBox2.Text);
                label1.Text = (counter+1).ToString();
                
                checkCriticalValue(criticalValue, valueArray);
            });
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            checkInputValue(richTextBox2.Text);
        }

        public void checkInputValue(string value)
        {
            if (!int.TryParse(value, out int i))
            {
                label2.Text = "Niste unijeli broj ili je prazno polje";
                return;
            }
            label2.Text = "Kritična vrijednost";
           
        }

        public void checkCriticalValue(int criticalValue, int[] valueArray)
        {
            if (counter <= valueArray.Length-1)
            {
                int i = counter;
                richTextBox1.Text = valueArray[i].ToString();
                Application.DoEvents();
                if (valueArray[i] > criticalValue)
                {
                    t.Stop();
                    MessageBox.Show(valueArray[i].ToString() + " je veci od kriticne vrijednosti, prekidam program.");
                    Application.Exit();
                }
            }
            if (counter >= valueArray.Length)
            {
                t.Stop();
                MessageBox.Show("Provjera gotova, nema vrijednosti vecih od kriticne.");
                Application.Exit();
            }
            counter++;
        }

        private void Form1_FormClosing(object sender,FormClosingEventArgs e)
        {
            citac.Close();
        }
    }
}
