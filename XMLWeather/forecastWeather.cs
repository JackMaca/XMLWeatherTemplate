using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace XMLWeather
{
    public partial class forecastWeather : UserControl
    {
        public forecastWeather()
        {
            InitializeComponent();

            // take info from the forecast weather file and display it to the screen

            // get information about current and forecast weather from the internet
            GetData();

            // take info from the forecast weather file and display it to the screen
            ExtractForecast();
        }

        private static void GetData()
        {
            WebClient client = new WebClient();

            string forecastFile = "http://api.openweathermap.org/data/2.5/forecast/daily?q=Stratford,CA&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0";

            //client.DownloadFile(forecastFile, "WeatherData7Day.xml");
        }

        private void ExtractForecast()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("WeatherData7Day.xml");

            //create a node variable to represent the parent element
            XmlNode parent;
            parent = doc.DocumentElement;
            int day = 1;

            //check each child of the parent element
            foreach (XmlNode child in parent.ChildNodes)
            {
                if (child.Name == "forecast")
                {
                    foreach (XmlNode grandChild in child.ChildNodes)
                    {
                        foreach (XmlNode greatGrandChild in grandChild.ChildNodes)
                        {
                            if (greatGrandChild.Name == "temperature")
                            {
                                switch (day)
                                {
                                    case 1:
                                        tempLabel1.Text = greatGrandChild.Attributes["day"].Value + "°C";
                                        break;
                                    case 2:
                                        tempLabel2.Text = greatGrandChild.Attributes["day"].Value + "°C";
                                        break;
                                    case 3:
                                        tempLabel3.Text = greatGrandChild.Attributes["day"].Value + "°C";
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (greatGrandChild.Name == "precipitation")
                            {
                                switch (day)
                                {
                                    case 1:
                                        rainLabel1.Text = greatGrandChild.Attributes["type"].Value;
                                        day++;
                                        break;
                                    case 2:
                                        rainLabel2.Text = greatGrandChild.Attributes["type"].Value;
                                        day++;
                                        break;
                                    case 3:
                                        rainLabel3.Text = greatGrandChild.Attributes["type"].Value;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
        }
    }
}
