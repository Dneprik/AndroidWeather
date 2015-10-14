using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NativeWeather.Models
{
    public class WeatherResponce
    {
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public string name { get; set; }
    }
}