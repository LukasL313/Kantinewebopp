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
   
    public Meny()
    {
       _connectionstring = ConfigurationHelper.GetConnectionString("DefaultConnection");
    }

    public async Task<List<Drikkevarer>> GetDrikkeMeny()
    {
        var drikkemeny = new List<Drikkevarer>();
        await using var connection = new NpgsqlConnection(_connectionstring);
        await connection.OpenAsync();

        var cmd = new NpgsqlCommand("SELECT (\"drikke_id\", \"drikke_vare\", \"drikke_besk\", \"drikke_pris\") VALUES (@drikke_vare, @drikke_besk, @drikke_pris) FROM drikkevarer", connection);
        await using var reader = await cmd.ExecuteReaderAsync();
        
        while (await reader.ReadAsync())
        {
            var drikkemenyen = new Drikkevarer(
              drikke_id: reader.GetInt32(reader.GetOrdinal("drikke_id")),
              drikke_vare: reader.GetString(reader.GetOrdinal("drikke_vare")),
              drikke_besk: reader.GetString(reader.GetOrdinal("drikke_besk")),
              drikke_pris: reader.GetDecimal(reader.GetOrdinal("drikke_pris"))
            ); 
            drikkemeny.Add(drikkemenyen);
        }
        return drikkemeny;
    }

    public async Task<List<Matvarer>> GetMatMeny()
    {
      var matmeny = new List<Matvarer>();
      await using var connection = new NpgsqlConnection(_connectionstring);
      await connection.OpenAsync();
      
      var cmd = new NpgsqlCommand("SELECT (\"mat_id\", \"mat_vare\", \"mat_besk\", \"mat_pris\") VALUES (@mat_vare, @mat_besk, @mat_pris) FROM matvarer", connection);
      await using var reader = await cmd.ExecuteReaderAsync();
      
      while (await reader.ReadAsync())
      {
        var matmenyen = new Matvarer( 
        mat_id: reader.GetInt32(reader.GetOrdinal("mat_id")),
        mat_vare: reader.GetString(reader.GetOrdinal("mat_vare")),
        mat_besk: reader.GetString(reader.GetOrdinal("mat_besk")),
        mat_pris: reader.GetDecimal(reader.GetOrdinal("mat_pris"))
        );
         matmeny.Add(matmenyen); // Operasjon til å legge matmenyen i matmeny listen. 
      }
      return matmeny;
    }
  }
}