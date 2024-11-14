using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookieCrumb
{
    public partial class Form1 : Form
    {

        Image test;
        Point position = new Point(200, 200);
        bool dragging;
        Rectangle rect;
        int height = 200, width = 200;
        public Form1()
        {
            test = Image.FromFile("test.png");
            rect = new Rectangle(position.X,position.Y, width, height);
            InitializeComponent();
        }

        private void FormTimerEvent(object sender, EventArgs e)
        {
            rect.X = position.X;
            rect.Y = position.Y;
            this.Invalidate();
        }

        private void MD(object sender, MouseEventArgs e)
        {
            Point mousePostion = new Point(e.X, e.Y);
            if (rect.Contains(mousePostion))
            {
                dragging = true;
            }
        }

        private void MM(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                position = e.Location;
            }
        }

        private void MU(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                dragging = false;
                rect.Location = new Point(e.X, e.Y);
            }
        }

        private void MP(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(test, position.X, position.Y, width, height);
        }
    }
}
