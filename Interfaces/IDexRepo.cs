using Pokemon_Random_Battle_Sim.Models;

namespace Pokemon_Random_Battle_Sim.Interfaces
{
    public interface IDexRepo
    {
        public IEnumerable<Pokemon> GetDex();
    }
}
