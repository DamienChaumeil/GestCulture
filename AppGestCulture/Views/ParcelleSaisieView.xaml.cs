using AppGestCulture.Data;
using AppGestCulture.Models;
using AppGestCulture.ViewModels;
using System.Data;

namespace AppGestCulture.Views
{

    public partial class ParcelleSaisieView : ContentPage
    {
        public ParcelleSaisieView(Exploitation exploitation)
        {
            InitializeComponent();
            BindingContext = new ParcelleSaisieViewModel(exploitation, this.Navigation);
        }

        public ParcelleSaisieViewModel ViewModel
        {
            get { return BindingContext as ParcelleSaisieViewModel; }
            set { BindingContext = value; }
        }
    }
}