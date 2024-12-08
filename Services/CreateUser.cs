using System;
using System.Threading.Tasks;
using Npgsql;
using KantinaWeb.Models;
using System.Collections.Generic;

namespace KantinaWeb.Services
{
  public class UserLogin
  {
    private readonly string _connectionstring;

    public UserLogin()
    {
       _connectionstring = ConfigurationHelper.GetConnectionString("DefaultConnection"); // Gir _configurationstring verdien til DBen 
    }
    
    public async Task Register(UserObjects users) // Logikk for å opprette bruker
    {        
       if (string.IsNullOrWhiteSpace(users.Brukernavn) || 
           string.IsNullOrWhiteSpace(users.Email) || 
           string.IsNullOrWhiteSpace(users.Passord))
       {
         throw new ArgumentException("Alle felt må ha en verdi");
       }
       
      await using var connection = new NpgsqlConnection(_connectionstring);
      await connection.OpenAsync();

      var cmd = new NpgsqlCommand("INSERT INTO bruker (\"brukernavn\", \"email\", \"passord\") VALUES (@brukernavn, @email, @passord)", connection);
      // SQL kommand som setter inn  bruker informasjon. 
      cmd.Parameters.AddWithValue("@brukernavn", users.Brukernavn);
      cmd.Parameters.AddWithValue("@email", users.Email);
      cmd.Parameters.AddWithValue("@passord", users.Passord);
      
      await cmd.ExecuteNonQueryAsync();
    }    

   public async Task<bool> Login(UserObjects users) // Sammenlign input data med DB data
    {
       await using var connection = new NpgsqlConnection(_connectionstring);
       await connection.OpenAsync(); 
       
       var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM bruker WHERE brukernavn = @brukernavn AND passord = @passord", connection);

       cmd.Parameters.AddWithValue("@brukernavn", users.Brukernavn);
       cmd.Parameters.AddWithValue("@passord", users.Passord);   

       var count = Convert.ToInt32(await cmd.ExecuteReaderAsync());
       return count > 0;
    } 
  }  
}