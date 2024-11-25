using System;
using System.Threading.Tasks;
using Npgsql;

namespace UserNamespace
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