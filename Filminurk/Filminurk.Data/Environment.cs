using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.Data
{
    public class Environment // rename class to just Environment
    {
        public static string smtpaddress = ""; // server address for sending emails via smtp
        public static string gmailusername = ""; // username of email sending user (gmail account)
        public static string gmailapppassword = ""; // password for user, that has access to this server (google app password)
        public static string accuweatherKey = "zpka_7c92a4944f914b05a0569a0983737752_2f1170c2"; // AccuWeather API key for fetching weather data
    }
}