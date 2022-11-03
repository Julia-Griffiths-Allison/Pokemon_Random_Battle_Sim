namespace Pokemon_Random_Battle_Sim.Models
{
    public class Pokemon
    {
        public int DexNumber { get; set; }
        public int NatNumber { get; set; }
        public string Name { get; set; }
        public string TypeOne { get; set; }
        public string TypeTwo { get; set; }
        public int IsBaseEvo { get; set; }
        public int IsSecondEvo { get; set; }
        public int IsFinalEvo { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
    }
}
