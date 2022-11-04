﻿namespace Pokemon_Random_Battle_Sim.Models
{
    public class Party
    {
        public Party()
        {
        }
        public int idParty { get; set; }
        public int DexNumber { get; set; }
        public int NatNumber { get; set; }
        public string? Name { get; set; }
        public string? TypeOne { get; set; }
        public string? TypeTwo { get; set; }
        public int IsBaseEvo { get; set; }
        public int IsSecondEvo { get; set; }
        public int IsFinalEvo { get; set; }
        public int HP { get; set; }
        public int CurrentHP { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
    }
}
