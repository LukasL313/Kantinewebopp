using System;
using System.Threading.Tasks;
using Npgsql;

namespace UserNamespace
{
    public class AdminPermissions
    {
        static async Task AdminImplementation()
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