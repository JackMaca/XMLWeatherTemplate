/// Jack MacAlpine
/// ICS4U
/// Mr. T
/// Weather XML
/// Program displays weather and allows users to switch between current weather and the forecast weather for the next few days.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace XMLWeather
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //opens Todays weather
            currentWeather cw = new currentWeather();
            this.Controls.Add(cw);
            cw.Location = new Point((this.Width - cw.Width) / 2, (this.Height - cw.Height) / 2);
            cw.Show();
        }
    }
}
