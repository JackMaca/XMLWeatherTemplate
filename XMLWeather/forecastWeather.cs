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
                                //puts corresponding dates at the top of each section
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
                            if (greatGrandChild.Name == "symbol")
                            {
                                switch (day)
                                {
                                    //change large image based on weather

                                    ///Somehow adding an empty case 1 wherever the 3 cases are used,
                                    ///it fixes the last day displayed from being the last day in the xml file.
                                    case 1:
                                        break;
                                    case 2:
                                        if (greatGrandChild.Attributes["name"].Value == "light rain")
                                        {
                                            cloudPicture1.BackgroundImage = Properties.Resources.lightrain;
                                        }
                                        else if (greatGrandChild.Attributes["name"].Value == "overcast clouds")
                                        {
                                            cloudPicture1.BackgroundImage = Properties.Resources.overcast;
                                        }
                                        else if (greatGrandChild.Attributes["name"].Value == "few clouds")
                                        {
                                            cloudPicture1.BackgroundImage = Properties.Resources.scattered;
                                        }
                                        else if (greatGrandChild.Attributes["name"].Value == "moderate rain")
                                        {
                                            cloudPicture1.BackgroundImage = Properties.Resources.raining;
                                        }
                                        else if (greatGrandChild.Attributes["name"].Value == "clear sky")
                                        {
                                            cloudPicture1.BackgroundImage = Properties.Resources.clear;
                                        }
                                        else if (greatGrandChild.Attributes["name"].Value == "heavy intensity rain")
                                        {
                                            cloudPicture1.BackgroundImage = Properties.Resources.heavyrain;
                                        }                             
                                        break;
                                    case 3:
                                        if (greatGrandChild.Attributes["name"].Value == "light rain")
                                        {
                                            cloudPicture2.BackgroundImage = Properties.Resources.lightrain;
                                        }
                                        else if (greatGrandChild.Attributes["name"].Value == "overcast clouds")
                                        {
                                            cloudPicture2.BackgroundImage = Properties.Resources.overcast;
                                        }
                                        else if (greatGrandChild.Attributes["name"].Value == "few clouds")
                                        {
                                            cloudPicture2.BackgroundImage = Properties.Resources.scattered;
                                        }
                                        else if (greatGrandChild.Attributes["name"].Value == "moderate rain")
                                        {
                                            cloudPicture2.BackgroundImage = Properties.Resources.raining;
                                        }
                                        else if (greatGrandChild.Attributes["name"].Value == "clear sky")
                                        {
                                            cloudPicture2.BackgroundImage = Properties.Resources.clear;
                                        }
                                        else if (greatGrandChild.Attributes["name"].Value == "heavy intensity rain")
                                        {
                                            cloudPicture2.BackgroundImage = Properties.Resources.heavyrain;
                                        }
                                        break;
                                    case 4:
                                        if (greatGrandChild.Attributes["name"].Value == "light rain")
                                        {
                                            cloudPicture3.BackgroundImage = Properties.Resources.lightrain;
                                        }
                                        else if (greatGrandChild.Attributes["name"].Value == "overcast clouds")
                                        {
                                            cloudPicture3.BackgroundImage = Properties.Resources.overcast;
                                        }
                                        else if (greatGrandChild.Attributes["name"].Value == "few clouds")
                                        {
                                            cloudPicture3.BackgroundImage = Properties.Resources.scattered;
                                        }
                                        else if (greatGrandChild.Attributes["name"].Value == "moderate rain")
                                        {
                                            cloudPicture3.BackgroundImage = Properties.Resources.raining;
                                        }
                                        else if (greatGrandChild.Attributes["name"].Value == "clear sky")
                                        {
                                            cloudPicture3.BackgroundImage = Properties.Resources.clear;
                                        }
                                        else if (greatGrandChild.Attributes["name"].Value == "heavy intensity rain")
                                        {
                                            cloudPicture3.BackgroundImage = Properties.Resources.heavyrain;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (greatGrandChild.Name == "temperature")
                            {
                                //Displays  temperature value and different images based on the temperature for the day
          
                                switch (day)
                                {
                                    case 1:
                                        break;
                                    case 2:
                                        tempLabel1.Text = greatGrandChild.Attributes["day"].Value + "°C";

                                        double day1Temp = Convert.ToDouble(greatGrandChild.Attributes["day"].Value);
                                        if (day1Temp <= -10)
                                        {
                                            tempPicture1.BackgroundImage = Properties.Resources.cold;
                                        }
                                        else if (day1Temp <= 9.99 && day1Temp >= -9.99)
                                        {
                                            tempPicture1.BackgroundImage = Properties.Resources.cool;
                                        }
                                        else if (day1Temp >= 10 && day1Temp <= 19.99)
                                        {
                                            tempPicture1.BackgroundImage = Properties.Resources.warm;
                                        }
                                        else
                                        {
                                            tempPicture1.BackgroundImage = Properties.Resources.hot;
                                        }
                                        break;
                                    case 3:
                                        tempLabel2.Text = greatGrandChild.Attributes["day"].Value + "°C";

                                        double day2Temp = Convert.ToDouble(greatGrandChild.Attributes["day"].Value);
                                        if (day2Temp <= -10)
                                        {
                                            tempPicture2.BackgroundImage = Properties.Resources.cold;
                                        }
                                        else if (day2Temp <= 9.99 && day2Temp >= -9.99)
                                        {
                                            tempPicture2.BackgroundImage = Properties.Resources.cool;
                                        }
                                        else if (day2Temp >= 10 && day2Temp <= 19.99)
                                        {
                                            tempPicture2.BackgroundImage = Properties.Resources.warm;
                                        }
                                        else
                                        {
                                            tempPicture2.BackgroundImage = Properties.Resources.hot;
                                        }
                                        break;
                                    case 4:
                                        tempLabel3.Text = greatGrandChild.Attributes["day"].Value + "°C";

                                        double day3Temp = Convert.ToDouble(greatGrandChild.Attributes["day"].Value);
                                        if (day3Temp <= -10)
                                        {
                                            tempPicture3.BackgroundImage = Properties.Resources.cold;
                                        }
                                        else if (day3Temp <= 9.99 && day3Temp >= -9.99)
                                        {
                                            tempPicture3.BackgroundImage = Properties.Resources.cool;
                                        }
                                        else if (day3Temp >= 10 && day3Temp <= 19.99)
                                        {
                                            tempPicture3.BackgroundImage = Properties.Resources.warm;
                                        }
                                        else
                                        {
                                            tempPicture3.BackgroundImage = Properties.Resources.hot;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (greatGrandChild.Name == "clouds")
                            {
                                //displays chance that rain will fall.
                                switch (day)
                                {
                                    //not sure if clouds > all is actually the precipitation chance
                                    case 1:
                                        day++;
                                        break;
                                    case 2:
                                        rainLabel1.Text = greatGrandChild.Attributes["all"].Value + "% Rain";
                                        day++;
                                        break;
                                    case 3:
                                        rainLabel2.Text = greatGrandChild.Attributes["all"].Value + "% Rain";
                                        day++;
                                        break;
                                    case 4:
                                        rainLabel3.Text = greatGrandChild.Attributes["all"].Value + "% Rain";
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

        private void todayButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            currentWeather cw = new currentWeather();
            f.Controls.Add(cw);
            f.Controls.Remove(this);
            cw.Location = new Point((this.Width - cw.Width) / 2, (this.Height - cw.Height) / 2);
        }
    }
}
