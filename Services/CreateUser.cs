using System;
using System.Threading.Tasks;
using Npgsql;
using KantinaWeb.Models;
using System.Collections.Generic;

namespace KantinaWeb.Services
{
  public class userLogin
  {
    private readonly string _connectionstring;

    public userLogin(string connectionstring)
    {
       _connectionstring = ConfigurationHelper.GetConnectionString("DefaultConnection"); // Henter DB string, samt gjør den gjenbrukbar
    }

    UserObjects users = new UserObjects("brukernavn","email","passord", 1);
    
    public async Task Register(UserObjects users) // Logikk for å opprette bruker
    {        
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
       // ... 
       
    }
  }   
}