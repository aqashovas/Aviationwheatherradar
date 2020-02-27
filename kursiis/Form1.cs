using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursiis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Controls.Add(pnlplane);
            //test();


        }
        
        public double Xcoor = 6371 * Math.Cos(38.28482222 * 3.14 / 180) * Math.Cos(44.96833333 * 3.14 / 180);
        public double Ycoor = 6371 * Math.Cos(38.28482222 * 3.14 / 180) * Math.Sin(44.96833333 * 3.14 / 180);
        public List<Point> pnts = new List<Point>();
        public List<Point> pntskorr = new List<Point>();
        public int i = 1, j = 1, k = 0, l = 1;
        public bool draw = false;
        public int x1, x2, y1, y2, x3, x4, y3, y4, x5, x6, y5, y6;

        private void button2_Click(object sender, EventArgs e)
        {
            timer3.Enabled = true;
            timer3.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Stop();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            Stop2();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (Point point in pnts)
            {
                e.Graphics.FillEllipse(Brushes.Red, point.X - 3, point.Y - 3, 10, 10);
                if (pnts.Count < 2)
                {
                    return;
                }
                e.Graphics.DrawCurve(Pens.Black, pnts.ToArray());
                e.Graphics.Save();
            }
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (Point point in pntskorr)
            {
                e.Graphics.FillEllipse(Brushes.Red, point.X - 3, point.Y - 3, 10, 10);
                if (pntskorr.Count < 2)
                {
                    return;
                }
                e.Graphics.DrawCurve(Pens.Black, pntskorr.ToArray());
                e.Graphics.Save();
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.Location.ToString());
            k++;
            if (draw == false && k < 3)
            {
                pnts.Add(e.Location);
                MessageBox.Show(e.Location.ToString());
            }
            else if (draw == true && k > 2)
            {
                pntskorr.Add(e.Location);
                MessageBox.Show(pntskorr.Count.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;

            richTextBox1.Clear();

            double y = Convert.ToDouble(pnlplane.Location.Y) + Ycoor - 276 /*+ pictureBox1.Height / 2*/;
            double x = Convert.ToDouble(pnlplane.Location.X) + Xcoor /*+ pictureBox1.Width / 2*/;
            double coord = Math.Atan2(y, x);
            double coord2 = Math.Atan2(x, y);
            coord2 = coord2 * 180.0 / Math.PI;
            coord = coord * 180.0 / Math.PI;
            double minutes = (coord - Math.Floor(coord)) * 60.0;
            double seconds = (minutes - Math.Floor(minutes)) * 60.0;
            double minutes2 = (coord2 - Math.Floor(coord2)) * 60.0;
            double seconds2 = (minutes2 - Math.Floor(minutes2)) * 60.0;
            //int sec = (int)Math.Round(coord * 3600);
            //int deg = sec / 3600;
            //sec = Math.Abs(sec % 3600);
            //int min = sec / 60;
            //sec %= 60;
            //textBox1.Text =(Convert.ToDouble(pictureBox1.Location.X)+Xcoor).ToString()+" "+ (Convert.ToDouble(pictureBox1.Location.Y) + Ycoor-660).ToString();
            richTextBox1.Text = "Lat=" + Math.Round(coord, 2).ToString() + "°" + Math.Round(minutes, 2).ToString() + "''" + Math.Round(seconds, 2).ToString() + "'" + Environment.NewLine + "Long=" + Math.Round(coord2, 2).ToString() + "°" + Math.Round(minutes2, 2).ToString() + "''" + Math.Round(seconds2, 2).ToString() + "'";
            x1 = pnts.First().X - pnlplane.Width / 2;
            x2 = pnts.Last().X - pnlplane.Width / 2;
            y1 = pnts.First().Y;
            y2 = pnts.Last().Y;
            x1 = x1 + (x2 - x1) * i / 500;
            y1 = y1 + (y2 - y1) * i / 500;
            pnlplane.Location = new Point(x1, y1);
        }
        public void test()
        {
            if (pntskorr.Count > 1)
            {
                timer3.Enabled = true;
                timer3.Start();
            }
        }
        public void Stop()
        {
            if ((pnlplane.Location.X == x2 && pnlplane.Location.Y == y2) || (draw == true && k > 2))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer1.Stop();
                MessageBox.Show("ubec");
              
            }
            // timer1.Stop();
        }
        public void Stop2()
        {
            if (pnlplane.Location.X == x4 && pnlplane.Location.Y == y4)
            {
                timer3.Enabled = false;
                timer3.Stop();
                timer4.Enabled = false;


            }
            // timer1.Stop();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            draw = true;
        }



        private void btnOk_Click(object sender, EventArgs e)
        {


            timer1.Enabled = true;
            timer1.Start();
            timer2.Enabled = true;
            timer2.Start();
        }

       


        private void timer3_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("vvjgv");
            j++;

            richTextBox1.Clear();

            double y = Convert.ToDouble(pnlplane.Location.Y) + Ycoor - 276 /*+ pictureBox1.Height / 2*/;
            double x = Convert.ToDouble(pnlplane.Location.X) + Xcoor /*+ pictureBox1.Width / 2*/;
            double coord = Math.Atan2(y, x);
            double coord2 = Math.Atan2(x, y);
            coord2 = coord2 * 180.0 / Math.PI;
            coord = coord * 180.0 / Math.PI;
            double minutes = (coord - Math.Floor(coord)) * 60.0;
            double seconds = (minutes - Math.Floor(minutes)) * 60.0;
            double minutes2 = (coord2 - Math.Floor(coord2)) * 60.0;
            double seconds2 = (minutes2 - Math.Floor(minutes2)) * 60.0;
            //int sec = (int)Math.Round(coord * 3600);
            //int deg = sec / 3600;
            //sec = Math.Abs(sec % 3600);
            //int min = sec / 60;
            //sec %= 60;
            //textBox1.Text =(Convert.ToDouble(pictureBox1.Location.X)+Xcoor).ToString()+" "+ (Convert.ToDouble(pictureBox1.Location.Y) + Ycoor-660).ToString();
            richTextBox1.Text = "Lat=" + Math.Round(coord, 2).ToString() + "°" + Math.Round(minutes, 2).ToString() + "''" + Math.Round(seconds, 2).ToString() + "'" + Environment.NewLine + "Long=" + Math.Round(coord2, 2).ToString() + "°" + Math.Round(minutes2, 2).ToString() + "''" + Math.Round(seconds2, 2).ToString() + "'";
            x3 = pntskorr.First().X - pnlplane.Width / 2;
            x4 = pntskorr.Last().X - pnlplane.Width / 2;
            y3 = pntskorr.First().Y;
            y4 = pntskorr.Last().Y;
            x3 = x3 + (x4 - x3) * j / 500;
            y3 = y3 + (y4 - y3) * j / 500;
            pnlplane.Location = new Point(x3, y3);
        }

    }
    
}
