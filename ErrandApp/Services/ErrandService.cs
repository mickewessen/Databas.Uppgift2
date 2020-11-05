using ErrandApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrandApp.Services
{
    public static class ErrandService
    {

        public static async Task CreateErrandAsync(string description, DateTime creationTime, string customerFirstName, string customerLastName, string customerEmail, int? customerPhonenumber, string status, string category, string createdby)
        {
            using DataContext context = new DataContext();

            context.Errand.Add(new Errand(description, creationTime, customerFirstName, customerLastName, customerEmail, customerPhonenumber, status, category, createdby));
            await context.SaveChangesAsync();
        }

        public static async Task UpdateErrandAsync(int id, string status, string comment)
        {
            using DataContext context = new DataContext();

            var Errand = await context.Errand.FindAsync(id);

            if (Errand != null)
            {
                Errand.Status = status;
                Errand.Comment = comment;
                context.Entry(Errand).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public static ObservableCollection<Errand> GetErrandsActive(string connectionString)
        {
            const string GetErrandsQuery = "SELECT * FROM ERRAND WHERE Status !='Closed'";

            var errands = new ObservableCollection<Errand>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetErrandsQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var errand = new Errand();
                                    errand.Id = reader.GetInt32(0);
                                    errand.Description = reader.GetString(1);
                                    errand.CreationTime = reader.GetDateTime(2);
                                    errand.CustomerFirstName = reader.GetString(3);
                                    errand.CustomerLastName = reader.GetString(4);
                                    errand.CustomerEmail = reader.GetString(5);
                                    errand.CustomerPhonenumber = reader.GetInt32(6);
                                    errand.Status = reader.GetString(7);
                                    errand.Category = reader.GetString(8);
                                    errand.Createdby = reader.GetString(9);
                                    errands.Add(errand);
                                }
                            }
                        }
                    }
                }
                return errands;
            }
            catch
            {

            }
            return null;
        }

        public static ObservableCollection<Errand> GetErrandsClosed(string connectionString)
        {
            const string GetErrandsQuery = "SELECT * FROM ERRAND WHERE Status ='Closed'";

            var errands = new ObservableCollection<Errand>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetErrandsQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var errand = new Errand();
                                    errand.Id = reader.GetInt32(0);
                                    errand.Description = reader.GetString(1);
                                    errand.CreationTime = reader.GetDateTime(2);
                                    errand.CustomerFirstName = reader.GetString(3);
                                    errand.CustomerLastName = reader.GetString(4);
                                    errand.CustomerEmail = reader.GetString(5);
                                    errand.CustomerPhonenumber = reader.GetInt32(6);
                                    errand.Status = reader.GetString(7);
                                    errand.Category = reader.GetString(8);
                                    errand.Createdby = reader.GetString(9);
                                    errand.Comment = reader.GetString(10);
                                    errands.Add(errand);
                                }
                            }
                        }
                    }
                }
                return errands;
            }
            catch
            {

            }
            return null;
        }
    }
}
