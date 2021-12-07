using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace VectorEditor_IT3A
{
    public partial class Form1 : Form
    {
        List<PointF> points;

        public Form1()
        {
            InitializeComponent();
            points = new List<PointF>();
        }

        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            this.Text = e.Location.ToString();
            points.Add(e.Location);
            Canvas.Refresh();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            if(points.Count > 1)
            {
                e.Graphics.DrawLines(Pens.Red, points.ToArray());
            }
            foreach (var point in points)
            {
                e.Graphics.FillRectangle(Brushes.Blue, point.X - 4, point.Y - 4, 8, 8);
            }
        }

        private void sfd_FileOk(object sender, CancelEventArgs e)
        {
            var json = JsonConvert.SerializeObject(points, Formatting.Indented);
            File.WriteAllText(sfd.FileName, json);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.S && e.Control)
            {
                sfd.ShowDialog();
            }
        }
    }
}
