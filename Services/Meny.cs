using System;
using Npgsql;
using KantinaWeb.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace KantinaWeb.Services
{
  public class Meny
  {
    private readonly string _connectionstring;
   
    public Meny(string connectionstring)
    {
       _connectionstring = ConfigurationHelper.GetConnectionString("DefaultConnection");
    }



    public async Task GetDrikkeMeny()
    {
        await using var connection = new NpgsqlConnection(_connectionstring);
        await connection.OpenAsync();

        Drikkevarer drikkemeny = new Drikkevarer();

        var cmd = new NpgsqlCommand("SELECT (\"drikke_id\", \"drikke_vare\", \"drikke_besk\") VALUES (@drikke_vare, @drikke_besk,) FROM drikkevarer", connection);
        await using var reader = await cmd.ExecuteNonQueryAsync();
        
        while (await reader.ReadAsync())
        {
            var drikkemenyen = new Drikkevarer(
              Drikke_id: reader.GetInt32(reader.GetOrdinal("Drikke_id")),
              Drikke_vare: reader.GetString(reader.GetOrdinal("drikke_vare")),
              Drikke_besk: reader.GetString(reader.GetOrdinal("drikke_besk"))
            );
            drikkemeny.Add(drikkemenyen);
        }
        return drikkemeny;
    }

    public async Task GetMatMeny()
    {
      
    }
    
  }
}