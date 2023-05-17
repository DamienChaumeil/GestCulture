using AppGestCulture.Data;
using AppGestCulture.Models;
using AppGestCulture.ViewModels;
using System.Data;

namespace AppGestCulture.Views
{

    public partial class MainPage : ContentPage
    {
        static Database database;
        readonly MainPageViewModel viewModel;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database();
                }
                return database;
            }
        }

        public MainPage(Database database)
        {
            InitializeComponent();
            viewModel = new MainPageViewModel();
            BindingContext = viewModel;
        }
    }
}