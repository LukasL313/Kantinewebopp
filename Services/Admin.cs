using System;
using System.Threading.Tasks;
using Npgsql;

namespace UserNamespace
{
    public interface Admin
    { 
        // Definerer hvilke operasjoner admin brukere kan gjøre
        // Logikken blir implementert i AdminPermissions.cs
        Task<List<UserObjects>> GetUsers();
     // Task<UserObjects> GetUser(int id);
        Task<bool> DeleteUser(int UserID);
        Task<bool> CreateUser(UserObjects UserID);
        Task<bool> UpdateUser (UserObjects UserID );
    }
}
