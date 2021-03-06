﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;
using PetInsights_all.OrgSide;
using PetInsights_all.SearchViews;

namespace PetInsights_all
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainSearch : ContentPage
    {
        public MainSearch()
        {
            InitializeComponent();
            searchFrame.BackgroundColor = Color.White;
            location.Text = Application.Current.Properties["UserLocation"].ToString();
            transparentColor0.BackgroundColor = new Color(1, 1, 1, 0.7);
            transparentColor1.BackgroundColor = new Color(1, 1, 1, 0.7);
            transparentColor2.BackgroundColor = new Color(1, 1, 1, 0.7);
            transparentColor3.BackgroundColor = new Color(1, 1, 1, 0.7);
            transparentColor4.BackgroundColor = new Color(1, 1, 1, 0.7);
            transparentColor5.BackgroundColor = new Color(1, 1, 1, 0.7);
            transparentColor6.BackgroundColor = new Color(1, 1, 1, 0.7);
            transparentColor7.BackgroundColor = new Color(1, 1, 1, 0.7);

            // = "Current Location = Application.Current.Properties["UserLocation"].ToString();
        }

        // code already exists in GetLocation.xaml.cs
        private bool ConfirmLocation(string location)
        {
            // NOTE - found this regex online
            if (Regex.IsMatch(location, "^[0-9]{5}(?:-[0-9]{4})?$"))
                return true;
            else
                return false;
        }


        public void OnEnterPressed(object sender, EventArgs e)
        {
            bool realZip = false;
            realZip = ConfirmLocation(location.Text);
            while (realZip == false)
            {
                // Add a pop up asking "Invalid Zip Code, please re-enter a valid zipcode"
                DisplayAlert("Alert", "Invalid Zipcode entered. Please re-enter a valid zip code", "OK");
                /*Device.BeginInvokeOnMainThread(() => {
                    DisplayAlert(e.Title, e.Message, "OK");
                });*/
                realZip = ConfirmLocation(location.Text);
                location.Text = string.Empty;
            }

            DisplayAlert("Good", "Valid zip code typed", "OK");
            Application.Current.Properties["UserLocation"] = location.Text;
            Application.Current.SavePropertiesAsync();
        }

  
        async void GoToOrgSite(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new OrgSignInPage());
        }

        async void GoToVolunteer(object sender, EventArgs e)
        {
            Console.WriteLine("clicked go to volunteer");
            await Application.Current.MainPage.Navigation.PushAsync(new VolunteerPage());
        }

        async void GoToDonate(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new DonatePage());
        }

        async void GoToOrgListView(object sender, EventArgs e)
        {
            //await Application.Current.MainPage.Navigation.PushAsync(new OrgListView()); // possibly broke nav bar
            await Navigation.PushAsync(new OrgListView());

        }

        async void onSearchFrame_Tapped(object sender, EventArgs e)
        {
            // await Navigation.PushModalAsync(new SimpleFilterModal());
            
            //await Application.Current.MainPage.Navigation.PushAsync(new PetListView(null, true));
            // temporary fix :)
            searchFrame.BackgroundColor = Color.LightGray;
            await Task.Delay(500);
            await Navigation.PushAsync(new PetListView(null, true));
            searchFrame.BackgroundColor = Color.White;
        }

        async void onLocationFrame_Tapped(object sender, EventArgs e)
        {
            // let user change location (not implementing for demo
        }

        async void onQuickSearchTapped(object sender, EventArgs e)
        {
            string _quickFilter = (sender as Frame).BindingContext as string;
            Console.WriteLine("in here");
            await Navigation.PushAsync(new PetListView(_quickFilter));
        }
    }
}