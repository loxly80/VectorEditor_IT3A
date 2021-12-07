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
        List<Object> objects;
        ShapeObject selectedShape = ShapeObject.None;
        Rectangle tempRectange;

        public Form1()
        {
            InitializeComponent();
            objects = new List<Object>();
        }

        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (selectedShape == ShapeObject.Point)
            {
                objects.Add(new Point(e.Location.X, e.Location.Y, Color.Blue, 8, Shape.Circle));
                Canvas.Refresh();
            }
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (var obj in objects)
            {
                obj.Draw(e.Graphics);                
            }
            if(tempRectange != null)
            {
                tempRectange.Draw(e.Graphics);
            }            
        }

        private void sfd_FileOk(object sender, CancelEventArgs e)
        {
            var json = JsonConvert.SerializeObject(objects, Formatting.Indented);
            File.WriteAllText(sfd.FileName, json);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.S && e.Control)
            {
                sfd.ShowDialog();
            }
        }

        private enum ShapeObject
        {
            None,
            Point,
            Rectangle
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            selectedShape = ShapeObject.Point;
            this.Text = selectedShape.ToString();
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            selectedShape = ShapeObject.Rectangle;
            this.Text = selectedShape.ToString();
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
