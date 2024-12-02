using System;
using System.Threading.Tasks;
using Npgsql;
using KantinaWeb.Models;
using System.Collections.Generic;

namespace KantinaWeb.Services
{
    public class AdminPermissions : IAdmin
    {
       private readonly string _connectionstring;

       public AdminPermissions(string connectionstring)
       {
         _connectionstring = ConfigurationHelper.GetConnectionString("DefaultConnection");
       }
       public async Task OpenAsync()
       {
         await using var connection = new NpgsqlConnection(_connectionstring);
         await connection.OpenAsync();
       }

        public async Task<List<UserObjects>> GetUsers()
        {
            var users = new List<UserObjects>();
            
            await using var connection = new NpgsqlConnection(_connectionstring);
            await connection.OpenAsync();

            var command = new NpgsqlCommand("SELECT * FROM bruker", connection); 
            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var user = new UserObjects(
                    brukernavn: reader.GetString(reader.GetOrdinal("Brukernavn")),
                    email: reader.GetString(reader.GetOrdinal("Email")),
                    passord: reader.GetString(reader.GetOrdinal("Passord")),
                    userid: reader.GetInt32(reader.GetOrdinal("Userid"))
                );
                users.Add(user);
            } 
            
            return users;
        }

       public Task<bool> DeleteUser(int UserID)
       {
          var users = new List<bool>();

           return Task.FromResult(false);
       }

       public Task<bool> UpdateUser(UserObjects UserID)
       {
         var users = new List<bool>();
         
          return Task.FromResult(false);
       }

       public Task<bool> CreateUser(UserObjects UserID)
       {
         var users = new List<bool>();

         return Task.FromResult(false);
       } 
    }
}