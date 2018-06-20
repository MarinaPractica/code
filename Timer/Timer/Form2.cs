using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer
{
    public partial class Form2 : Form
    {
        private DateTime finishTime;
        private DateTime startTime;
        
        public Form2()
        {
            InitializeComponent();
        }

        private void pusk(object sender, EventArgs e)
        {
            if (numericUpDown1.Value!=0 || numericUpDown2.Value!=0)
            {
                button1.Enabled=true;
            }
            else button1.Enabled = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = !groupBox1.Visible;

            if (!groupBox1.Visible)
            {
                button1.Text = "Стоп";
                startTime = DateTime.Now;
                finishTime = startTime + new TimeSpan(0, int.Parse((numericUpDown1.Value).ToString()), int.Parse((numericUpDown2.Value).ToString()));
                timer1_Tick(this, null);
            }
            else { label1.Text = "00:00"; button1.Text = "Пуск"; numericUpDown1.Value = 0; numericUpDown2.Value = 0; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!groupBox1.Visible)
            {
                timer1.Enabled = true;
                if ((finishTime - DateTime.Now).CompareTo(new TimeSpan(0, 0, 0)) > 0)
                {
                    TimeSpan s = finishTime - DateTime.Now;
                    label1.Text = string.Format("Timer: {0}:{1}", s.Minutes, s.Seconds);
                }
                else { timer1.Enabled = false; MessageBox.Show("Заданный интервал времени истек", "Таймер", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); button1.Text = "Пуск"; }

            }
            else { label1.Text = "00:00"; }
        }
    }
}
