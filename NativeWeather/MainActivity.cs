using System;
using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using NativeWeather.Services.Weather;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace NativeWeather
{
    [Activity(Label = "NativeWeather", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FragmentActivity
    {
        private ViewPager _viewPager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            _viewPager.Adapter = new AwersomeFragmentAdapter(SupportFragmentManager);
        }

        private void TodayTemperatureView_Click1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        protected override void OnResume()
        {
            base.OnResume();
        }
    }

    public class AwersomeFragmentAdapter : FragmentPagerAdapter
    {
        public AwersomeFragmentAdapter(FragmentManager fm) : base(fm)
        {
        }

        public override int Count { get; } = 2;


        public override Fragment GetItem(int position)
        {
            return new AwersomeFragment(position);
        }
    }

    public class AwersomeFragment : Fragment
    {
        private TextView _city;
        private readonly int _fragment;
        private Button _selectCity;
        private EditText _selectCityField;
        private TextView _weatherToday;
        private readonly IWeatherService ws = new WeatherService();

        public AwersomeFragment(int fragment)
        {
            _fragment = fragment;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = new View(Context);


            switch (_fragment)
            {
                case 0:
                    view = inflater.Inflate(Resource.Layout.firstfragment, container, false);
                    break;
                    ;
                case 1:
                    view = inflater.Inflate(Resource.Layout.secondfragment, container, false);
                    break;
            }
            GetLinksToViews(view);

            return view;
        }

        private void GetLinksToViews(View view)
        {
            if (view.FindViewById(Resource.Id.todayWeather) != null)
            {
                _weatherToday = view.FindViewById<TextView>(Resource.Id.todayWeather);
            }
            if (view.FindViewById(Resource.Id.todayWeather) != null)
            {
                _city = view.FindViewById<TextView>(Resource.Id.city);
            }
            if (view.FindViewById(Resource.Id.todayWeather) != null)
            {
                _selectCityField = view.FindViewById<EditText>(Resource.Id.cityField);
            }
            if (view.FindViewById(Resource.Id.todayWeather) != null)
            {
                _selectCity = view.FindViewById<Button>(Resource.Id.btnSelectCity);
                _selectCity.Click += _selectCity_Click;
            }
        }


        private void _selectCity_Click(object sender, EventArgs e)
        {
            GetTemperature(_selectCityField.Text);
        }


        private async void GetTemperature(string city)
        {
            if (city != "")

            {
                var temp = await ws.GetTemperatureAndCityyAsync(city);

                if (temp.Item1 == city)
                {
                    _city.Text = temp.Item1;

                    _weatherToday.Text = Convert.ToInt32(temp.Item2) + "°C";
                }
                else
                {
                    _city.Text = "Sorry";
                    _weatherToday.Text = "City doesn't exist";
                }
            }
        }
    }
}