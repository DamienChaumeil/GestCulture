using AppGestCulture.Data;
using AppGestCulture.Models;
using AppGestCulture.ViewModels;
using System.Data;

namespace AppGestCulture.Views
{

    public partial class ParcelleDetailsView : ContentPage
    {
        public ParcelleDetailsView(Parcelle parcelle, Espece espece)
        {
            InitializeComponent();
            ViewModel = new ParcelleDetailsViewModel(parcelle, espece, this.Navigation);
            BindingContext = ViewModel;
        }
        protected override async void OnAppearing()
        {
            await ViewModel.UpdateEspeceAsync();
            base.OnAppearing();
        }
        public ParcelleDetailsViewModel ViewModel
        {
            get { return BindingContext as ParcelleDetailsViewModel; }
            set { BindingContext = value; }
        }
    }
}