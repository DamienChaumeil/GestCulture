using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AppGestCulture.Views;
using AppGestCulture.Data;
using AppGestCulture.Models;
using Android.Util;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppGestCulture.ViewModels
{
    internal class MainPageViewModel
    {
        private string Username { get; set; }
        private string Password { get; set; }
        private string ErrorMessage { get; set; }
        public ICommand BinLoginCommand { get; set; }
        private static Database database = null;

        public string BinUsername
        {
            get { return Username; }
            set { Username = value; }
        }

        public string BinPassword
        {
            get { return Password; }
            set { Password = value; }
        }

        public string BinErrorMessage
        {
            get { return ErrorMessage; }
            set { 
                ErrorMessage = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel()
        {
            BinLoginCommand = new Command(async () => await userLogin());
        }
        private async Task userLogin()
        {
            try
            {
                var listTechnicien = await GetConnection().GetAllTechnicien();
                if (listTechnicien.Count == 0)
                {
                    await GetConnection().InsertTechnicien(new Technicien() {
                        Matricule = Constants.TechnicienMatricule,
                        Nom = "Default",
                        Prenom = "Default",
                        Mdp = Constants.TechnicienMdp
                    });
                }
                if (await GetConnection().CheckTechnicienByInfo(BinUsername, BinPassword))
                {
                    Application.Current.MainPage = new NavigationPage(new ExploitationView());
                }
                else 
                {
                    App.Current.MainPage.DisplayAlert("Alert", "Les informations de connexions ne sont pas valides", "OK");
                }
            }
            catch (Exception ex)
            {

            }
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
