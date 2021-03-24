using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetInsights_all
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainProfile : ContentPage
    {
        public MainProfile()
        {
            InitializeComponent();
        }
        async void LoginButton_clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Login", "Logged In", "OK");
        }
    }
}