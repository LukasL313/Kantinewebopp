using System;
using System.Threading.Tasks;
using Npgsql;

namespace UserNamespace
{
    public class AdminPermissions
    {
       private readonly string _connectionstring;

       public AdminPermissions(string connectionstring)
       {
         _connectionstring = connectionstring;
       }
       public async Task OpenAsync()
       {
         await using var connection = new NpgsqlConnection(_connectionstring);
         await connection.OpenAsync();
       }

       public async Task<List<UserObjects>> GetUser()
       {
         var users = new List<UserObjects>();

         await using var connection = new NpgsqlConnection(_connectionstring);
         await connection.OpenAsync();

         var command = new NpgsqlCommand("SELECT userid, brukernavn, email");
         

  
        return users;
       }
    }
}