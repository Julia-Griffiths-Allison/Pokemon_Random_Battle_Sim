using Dapper;
using Pokemon_Random_Battle_Sim.Interfaces;
using Pokemon_Random_Battle_Sim.Models;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Pokemon_Random_Battle_Sim.Repos
{
    public class PartyRepo : IPartyRepo
    {
        private readonly IDbConnection _conn;
        public PartyRepo(IDbConnection conn)
        {
            _conn = conn;
        }
        public List<int> GetSixRandomNumbers()
        {
            var rng = new Random();
            var randomNumbers = new List<int>();
            for (int i = 1; i <= 6; i++)
            {
                randomNumbers.Add(rng.Next(1, 201));
            }
            return randomNumbers;
        }

        public void CreateTeam()
        {
            var list = GetSixRandomNumbers();
            var team = new List<Pokemon>();
            var id = 1;
            foreach (var number in list)
            {
                team.Add(_conn.QuerySingle<Pokemon>($"Select * from pokedex Where DexNumber = {number};"));
            }
            foreach (var item in team)
            {
                _conn.Execute($"Update party Set DexNumber = '{item.DexNumber}', " +
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
                    $"Where idParty = {id};");
                id++;
            }
        }

        public IEnumerable<Party> DisplayNewTeam()
        {
            return _conn.Query<Party>("Select * from party;");
        }
    }
}
