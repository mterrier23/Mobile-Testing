using PetInsights_all.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetInsights_all.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PetInsights_all.SearchViews;
using System.Collections.ObjectModel;

namespace PetInsights_all.Search
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetDetailsPage : ContentPage
    {
        DBFirebase services;
        Pet pet;

        private ObservableCollection<string> _comments = new ObservableCollection<string>();

        public ObservableCollection<string> Comments
        {
            get { return _comments; }
            set
            {
                _comments = value;
                OnPropertyChanged();
            }
        }

        public PetDetailsPage(Pet _pet)
        {
            // NOTE -- GETTING NULL POINTER SOMEWHERE HERE !!
            Console.WriteLine("in pet details page");
            InitializeComponent();
            Comments = services.getComments(_pet); 
            pet = _pet;
            BindingContext = _pet;
            services = new DBFirebase();
        }

        public async void BtnUpdate_Pet(object sender, EventArgs e)
        {
            await services.UpdatePet(pet, 
                Name.Text, int.Parse(Age.Text));
            await Navigation.PopAsync();
        }

        public async void BtnAddComment(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCommentPage(pet));
            //await Navigation.PopAsync();
        }
    }
}