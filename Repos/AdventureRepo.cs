using Dapper;
using Pokemon_Random_Battle_Sim.Interfaces;
using Pokemon_Random_Battle_Sim.Models;
using System.Data;

namespace Pokemon_Random_Battle_Sim.Repos
{
    public class AdventureRepo : IAdventureRepo
    {
        private readonly IDbConnection _conn;
        private readonly IPartyRepo _repo;
        public AdventureRepo(IDbConnection conn, IPartyRepo repo)
        {
            _conn = conn;
            _repo = repo;
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
                    $"CurrentHP = '{item.HP * 40}', " +
                    $"Attack = '{item.Attack}', " +
                    $"Defence = '{item.Defence}' " +
                    $"Where idNPCParty = {id};");
                id++;
            }
        }
        public ViewTeams DisplayNewTeam()
        {
            var teamA = new ViewTeams();
            teamA.Adventures = _conn.Query<Adventure>("Select * from npc_party;");
            teamA.Parties = _repo.DisplayNewTeam();
            return teamA;
        }

        public IEnumerable<Adventure> DisplayEncounter()
        {
            return _conn.Query<Adventure>("Select * from npc_party Limit 1;");
        }
        //public int FireSpecialAttack() --usable, but not finished
        //{
        //    var pokemon = new Adventure();
        //    var fireAttack = pokemon.Attack * 20;

        //    if (pokemon.TypeOne == "Grass" || pokemon.TypeTwo == "Grass" || pokemon.TypeOne == "Ice" || pokemon.TypeTwo == "Ice" || pokemon.TypeOne == "Bug" || pokemon.TypeTwo == "Bug" || pokemon.TypeOne == "Steel" || pokemon.TypeTwo == "Steel")
        //    {
        //        return fireAttack * 2;
        //    }
        //    else
        //    {
        //        return fireAttack;
        //    }
        //    //var defence = pokemon.Defence * 10;
        //    //var hpBaseValue = pokemon.HP * 40;
        //    //var hpFormula = defence - fireAttack;
        //    //var currentHP = 0;
        //    //currentHP = hpBaseValue;
        //}
        //public int AttackSequence()
        //{
        //    var pokemon = new Adventure();

        //    var attack = pokemon.Attack * 20;
        //    var defence = pokemon.Defence * 10;
        //    var currentHP = pokemon.CurrentHP;
        //    var formula = defence - attack;
        //    currentHP = currentHP + formula;
        //    return currentHP;
            
        //}
    }
}
