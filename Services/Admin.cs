using System;
using System.Threading.Tasks;
using Npgsql;
using KantinaWeb.Models;

namespace KantinaWeb.Services

{
    public interface IAdmin
    { 
    // Definerer hvilke operasjoner admin brukere kan gjøre
    // Logikken blir implementert i AdminPermissions.cs
        Task<List<UserObjects>> GetUsers();
     // Task<UserObjects> GetUser(int id);
        Task<bool> DeleteUser(int UserID);
        Task<bool> CreateUser(UserObjects UserID);
        Task<bool> UpdateUser (UserObjects UserID);
    }
}
