using Android.Util;
using AppGestCulture.Models;
using AppGestCulture.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Android.Net.Wifi.WifiEnterpriseConfig;
using static Android.Provider.CalendarContract;
using AppGestCulture.Views;

namespace AppGestCulture.ViewModels
{
    public partial class ParcelleDetailsViewModel
    {
        public Parcelle Parcelle { get; set; }
        public Espece Espece { get; set; }
        public String EspeceNom { get; set; }
        private static Database database = null;
        public ICommand btnUpdateParcelle { get; set; }

        private INavigation navigation;

        public ParcelleDetailsViewModel(Parcelle parcelle, Espece espece, INavigation _navigation)
        {
            navigation = _navigation;
            btnUpdateParcelle= new Command(async () => updateParcelle());

            Parcelle = parcelle;
            Espece = espece;
            UpdateEspeceAsync();
        }
        public async Task UpdateEspeceAsync()
        {
            OnPropertyChanged("EspeceNom");
        }
        private async Task updateParcelle()
        {
            await Navigation.PushAsync(new ParcelleEditView(Parcelle));
        }

        public INavigation Navigation
        {
            get { return navigation; }
            set { navigation = value; }
        }
        private static Database GetConnection()
        {
            if (database == null)
                database = new Database();
            return database;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
