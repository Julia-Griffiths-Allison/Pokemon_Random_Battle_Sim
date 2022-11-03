using Dapper;
using Pokemon_Random_Battle_Sim.Interfaces;
using Pokemon_Random_Battle_Sim.Models;
using System.Data;

namespace Pokemon_Random_Battle_Sim.Repos
{
    public class AdventureRepo : IAdventureRepo
    {
        private readonly IDbConnection _conn;
        public AdventureRepo(IDbConnection conn)
        {
            _conn = conn;
        }
        public List<int> GetSixRandomNumber()
        {
            var rng = new Random();
            var randomNumbers = new List<int>();
            for (int i = 1; i <= 6; i++)
            {
                randomNumbers.Add(rng.Next(1, 201));
            }
            return randomNumbers;
        }
        public void CreateNPCTeam()
        {
            var list = GetSixRandomNumber();
            var team = new List<Pokemon>();
            var id = 1;
            foreach (var number in list)
            {
                team.Add(_conn.QuerySingle<Pokemon>($"Select * from pokedex Where DexNumber = {number};"));
            }
            foreach (var item in team)
            {
                _conn.Execute($"Update npc_party Set DexNumber = '{item.DexNumber}', " +
                    $"NatNumber = '{item.NatNumber}', " +
                    $"Name = '{item.Name}', " +
                    $"TypeOne = '{item.TypeOne}', " +
                    $"TypeTwo = '{item.TypeTwo}', " +
                    $"IsBaseEvo = '{item.IsBaseEvo}', " +
                    $"IsSecondEvo = '{item.IsSecondEvo}', " +
                    $"IsFinalEvo = '{item.IsFinalEvo}', " +
                    $"HP = '{item.HP}', " +
                    $"Attack = '{item.Attack}', " +
                    $"Defence = '{item.Defence}' " +
                    $"Where idNPCParty = {id};");
                id++;
            }
        }
        public IEnumerable<Adventure> DisplayNewTeam()
        {
            return _conn.Query<Adventure>("Select * from npc_party;");
        }
        
        public IEnumerable<Adventure> DisplayEncounter()
        {
            return _conn.Query<Adventure>("Select * from npc_party Limit 1;");
        }
    }
}
