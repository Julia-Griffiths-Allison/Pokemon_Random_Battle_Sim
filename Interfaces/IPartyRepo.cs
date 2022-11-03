using Pokemon_Random_Battle_Sim.Models;
using Pokemon_Random_Battle_Sim.Repos;

namespace Pokemon_Random_Battle_Sim.Interfaces
{
    public interface IPartyRepo
    {
        public List <int>GetSixRandomNumbers();
        public void CreateTeam();
        public IEnumerable<Party> DisplayNewTeam();
       
    }
}
