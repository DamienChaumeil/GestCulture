using AppGestCulture.Data;
using System.Data;

namespace AppGestCulture.Views
{

    public partial class ChoixOption : ContentPage
    {
        private readonly Database database;
        public ChoixOption()
        {
            InitializeComponent();
        }

        private async void SaisiParcelle(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SaisieParcelle());
        }

        private void EnvoieDonnee(object sender, EventArgs e)
        {

        }
    }
}