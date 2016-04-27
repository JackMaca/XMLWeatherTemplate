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
                        if (grandChild.Name == "time")
                        {
                            switch (day)
                            {
                                case 1:
                                    dateLabel1.Text = grandChild.Attributes["day"].Value;
                                    break;
                                case 2:
                                    dateLabel2.Text = grandChild.Attributes["day"].Value;
                                    break;
                                case 3:
                                    dateLabel3.Text = grandChild.Attributes["day"].Value;
                                    break;
                                default:
                                    break;
                            }
                        }
                        foreach (XmlNode greatGrandChild in grandChild.ChildNodes)
                        {
                            if (greatGrandChild.Name == "temperature")
                            {
                                switch (day)
                                {
                                    case 1:
                                        tempLabel1.Text = greatGrandChild.Attributes["day"].Value + "°C";
                                        day++;
                                        break;
                                    case 2:
                                        tempLabel2.Text = greatGrandChild.Attributes["day"].Value + "°C";
                                        day++;
                                        break;
                                    case 3:
                                        tempLabel3.Text = greatGrandChild.Attributes["day"].Value + "°C";
                                        break;
                                    default:
                                        break;
                                }
                            }
                            //if (greatGrandChild.Name == "symbol")
                            //{
                            //    switch (day)
                            //    {
                            //        case 1:
                            //            //capitalize text and display related image
                            //            #region day1 properties
                            //            if (child.Attributes["name"].Value == "light rain")
                            //            {
                            //                rainLabel1.Text = "Light Rain";
                            //                cloudPicture1.BackgroundImage = Properties.Resources.lightrain;
                            //            }
                            //            else if (child.Attributes["name"].Value == "few clouds")
                            //            {
                            //                rainLabel1.Text = "Few Clouds";
                            //                cloudPicture1.BackgroundImage = Properties.Resources.scattered;
                            //            }
                            //            else if (child.Attributes["name"].Value == "moderate rain")
                            //            {
                            //                rainLabel1.Text = "Moderate Rain";
                            //                cloudPicture1.BackgroundImage = Properties.Resources.raining;
                            //            }
                            //            else if (child.Attributes["name"].Value == "clear sky")
                            //            {
                            //                rainLabel1.Text = "Clear Sky";
                            //                cloudPicture1.BackgroundImage = Properties.Resources.clear;
                            //            }
                            //            else if (child.Attributes["name"].Value == "heavy intensity rain")
                            //            {
                            //                rainLabel1.Text = "Heavy Intensity Rain";
                            //                cloudPicture1.BackgroundImage = Properties.Resources.heavyrain;
                            //            }
                            //            #endregion
                            //            day++;
                            //            break;
                            //        case 2:
                            //            #region day2 properties
                            //            if (child.Attributes["name"].Value == "light rain")
                            //            {
                            //                rainLabel2.Text = "Light Rain";
                            //                cloudPicture2.BackgroundImage = Properties.Resources.lightrain;
                            //            }
                            //            else if (child.Attributes["name"].Value == "few clouds")
                            //            {
                            //                rainLabel2.Text = "Few Clouds";
                            //                cloudPicture2.BackgroundImage = Properties.Resources.scattered;
                            //            }
                            //            else if (child.Attributes["name"].Value == "moderate rain")
                            //            {
                            //                rainLabel2.Text = "Moderate Rain";
                            //                cloudPicture2.BackgroundImage = Properties.Resources.raining;
                            //            }
                            //            else if (child.Attributes["name"].Value == "clear sky")
                            //            {
                            //                rainLabel2.Text = "Clear Sky";
                            //                cloudPicture2.BackgroundImage = Properties.Resources.clear;
                            //            }
                            //            else if (child.Attributes["name"].Value == "heavy intensity rain")
                            //            {
                            //                rainLabel2.Text = "Heavy Intensity Rain";
                            //                cloudPicture2.BackgroundImage = Properties.Resources.heavyrain;
                            //            }
                            //            #endregion
                            //            day++;
                            //            break;
                            //        case 3:
                            //            #region day3 properties
                            //            if (child.Attributes["name"].Value == "light rain")
                            //            {
                            //                rainLabel3.Text = "Light Rain";
                            //                cloudPicture3.BackgroundImage = Properties.Resources.lightrain;
                            //            }
                            //            else if (child.Attributes["name"].Value == "few clouds")
                            //            {
                            //                rainLabel3.Text = "Few Clouds";
                            //                cloudPicture3.BackgroundImage = Properties.Resources.scattered;
                            //            }
                            //            else if (child.Attributes["name"].Value == "moderate rain")
                            //            {
                            //                rainLabel3.Text = "Moderate Rain";
                            //                cloudPicture3.BackgroundImage = Properties.Resources.raining;
                            //            }
                            //            else if (child.Attributes["name"].Value == "clear sky")
                            //            {
                            //                rainLabel3.Text = "Clear Sky";
                            //                cloudPicture3.BackgroundImage = Properties.Resources.clear;
                            //            }
                            //            else if (child.Attributes["name"].Value == "heavy intensity rain")
                            //            {
                            //                rainLabel3.Text = "Heavy Intensity Rain";
                            //                cloudPicture3.BackgroundImage = Properties.Resources.heavyrain;
                            //            }
                            //            #endregion
                            //            break;
                            //        default:
                            //            break;
                            //    }
                            //}
                        }
                    }
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
        }

        private void todayButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            forecastWeather fw = new forecastWeather();
            f.Controls.Add(fw);
            f.Controls.Remove(this);
            fw.Location = new Point((this.Width - fw.Width) / 2, (this.Height - fw.Height) / 2);
        }
    }
}
