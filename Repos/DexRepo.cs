using Dapper;
using Pokemon_Random_Battle_Sim.Interfaces;
using Pokemon_Random_Battle_Sim.Models;
using System.Data;

namespace Pokemon_Random_Battle_Sim.Repos
{
    public class DexRepo : IDexRepo
    {
        private readonly IDbConnection _conn;
        public DexRepo(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Pokemon> GetDex()
        {
            return _conn.Query<Pokemon>("Select * From pokedex;");
        }
    }
} 
