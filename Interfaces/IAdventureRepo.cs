using Pokemon_Random_Battle_Sim.Models;

namespace Pokemon_Random_Battle_Sim.Interfaces
{
    public interface IAdventureRepo
    {
        public List<int> GetSixRandomNumber();
        public void CreateNPCTeam();
        public ViewTeams DisplayNewTeam();
        public IEnumerable<Adventure> DisplayEncounter();

       
        //public int AttackSequence();
    }
}
