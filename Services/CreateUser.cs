using System;
using System.Threading.Tasks;
using Npgsql;
using KantinaWeb.Models;

namespace KantinaWeb.Services
{
    public class CreateUser
    {
         static async Task CreatingUser()
         {
            string connectionString = ConfigurationHelper.GetConnectionString("DefaultConnection");

            try
            {
                await using (var connection = new NpgsqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                } 
            }
            catch (System.Exception)
            {  
                throw;
            }
         }
    }
}