using AppGestCulture.Data;
using AppGestCulture.Models;
using System.Data;

namespace AppGestCulture.Views
{

    public partial class MainPage : ContentPage
    {
        private readonly Database database;

        public MainPage(Database database)
        {
            InitializeComponent();
            this.database = database;
        }

        private async void Onclicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChoixOption());
        }

    }

}