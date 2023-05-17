using AppGestCulture.Models;
using SQLite;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.ObjectModel;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensionsAsync.Extensions;

namespace AppGestCulture.Data
{

    public class Database
    {
        readonly SQLiteAsyncConnection connection;
        public Database()
        {
            connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);

            connection.CreateTableAsync<Technicien>().Wait();
            connection.CreateTableAsync<Espece>().Wait();
            connection.CreateTableAsync<Exploitation>().Wait();
            connection.CreateTableAsync<Parcelle>().Wait();
        }
        public async Task<IEnumerable<Espece>> GetAllEspece()
        {
            var especes = await connection.Table<Espece>().ToListAsync();
            if (especes.Count() == 0)
            {
                await InsertEspece(new Espece() { Nom = "Blé" });
                await InsertEspece(new Espece() { Nom = "Orge" });
                await InsertEspece(new Espece() { Nom = "Betteraves" });
            }
            return await connection.Table<Espece>().ToListAsync();
        }
        public async Task<bool> CheckTechnicienByInfo(string username, string password)
        {
            var result = await connection.Table<Technicien>().Where(t => (t.Matricule == username && t.Mdp == password)).ToListAsync();
            return result.Count > 0;
        }
        public Task<List<Technicien>> GetAllTechnicien()
        {
            return connection.Table<Technicien>().ToListAsync();
        }
        public async Task<int> InsertTechnicien(Technicien technicien)
        {
            return await connection.InsertAsync(technicien);
        }
        public async Task<int> InsertEspece(Espece espece)
        {
            return await connection.InsertAsync(espece);
        }
        public async Task<Espece> GetEspece(int id_espece)
        {
            return await connection.FindAsync<Espece>(id_espece);
        }

        public async Task<Technicien> GetTechnicien(int id_technicien)
        {
            return await connection.FindAsync<Technicien>(id_technicien);
        }


        public async Task<int> InsertParcelle(Parcelle parcelle)
        {
            return await connection.InsertAsync(parcelle);
        }
        public Task<int> UpdateParcelle(Parcelle parcelle)
        {
            return connection.UpdateAsync(parcelle);
        }
        public Task<int> DeleteParcelle(Parcelle parcelle)
        {
            return connection.DeleteAsync(connection.FindAsync<Parcelle>(parcelle.Id_parc));
        }
        public async Task<IEnumerable<Parcelle>> GetAllParcelleById(Exploitation exploitation)
        {
            return await connection.Table<Parcelle>().Where(e => e.Id_exploi == exploitation.Id_exploi).ToListAsync();
        }
        public async Task<Parcelle> GetParcelle(int id_parcelle)
        {
            return await connection.FindAsync<Parcelle>(id_parcelle);
        }


        public async Task<int> InsertExploitation(Exploitation exploitation)
        {
            return await connection.InsertAsync(exploitation);
        }
        public Task UpdateExploitation(Exploitation exploitation)
        {
            return connection.UpdateWithChildrenAsync(exploitation);
        }
        public Task<int> DeleteExploitation(Exploitation exploitation)
        {
            return connection.DeleteAsync(exploitation);
        }
        public async Task<IEnumerable<Exploitation>> GetAllExploitation()
        {
            await connection.CreateTableAsync<Exploitation>();
            return await connection.GetAllWithChildrenAsync<Exploitation>();
        }
        public async Task<Exploitation> GetExploitation(int id_exploitation)
        {
            return await connection.GetWithChildrenAsync<Exploitation>(id_exploitation);
        }
    }
}