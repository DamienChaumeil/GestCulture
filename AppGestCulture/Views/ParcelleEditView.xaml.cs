using AppGestCulture.Models;
using AppGestCulture.ViewModels;

namespace AppGestCulture.Views;

public partial class ParcelleEditView : ContentPage
{
    public ParcelleEditView(Parcelle parcelle)
    {
        InitializeComponent();
        BindingContext = new ParcelleEditViewModel(parcelle, this.Navigation);
    }
}